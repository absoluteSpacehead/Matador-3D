using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{

    public string[] lines;
    int currentletter;
    int currentstring;
    string currenttext;
    string fulltext;
    bool textboxopen;
    TextMeshProUGUI texttext;
    GameObject textboxparent;
    SpriteRenderer color;
    Image ArrowColor;
    Animator ArrowAnimate;
    AudioSource audio;
    AudioSource snap;
    public AudioClip snapsound;
    public AudioClip clap;
    public AudioClip textsoundclip;
    AudioSource textsound;
    bool a;
    float framecount;
    bool soundplaying;

    // Start is called before the first frame update
    void Start()
    {
        //set the funnies
        currentletter = 0;

        snap = gameObject.AddComponent<AudioSource>();
        snap.clip = snapsound;

        textsound = gameObject.AddComponent<AudioSource>();
        textsound.clip = textsoundclip;
        textsound.volume = 0;
        textsound.reverbZoneMix = 0;
        textsound.loop = true;

        snap.reverbZoneMix = 0;

        audio = GetComponent<AudioSource>();

        soundplaying = false;

        textboxparent = GameObject.Find("textbox");
        texttext = GameObject.Find("TextBoxText").GetComponent<TextMeshProUGUI>();
        texttext.enableKerning = true;
        ArrowColor = GameObject.Find("TextBoxArrow").GetComponent<Image>();
        ArrowColor.color = new Color(255,255,255,0);
        ArrowAnimate = GameObject.Find("TextBoxArrow").GetComponent<Animator>();
        ArrowAnimate.enabled = false;
        textboxparent.SetActive(false);

        color = GetComponentInChildren<SpriteRenderer>();
        color.color = new Color(255,255,255,0);

        framecount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(a) {
            if(color.color.a < 1) {
                color.color = new Color(255,255,255, color.color.a + 0.1f);
            }
        } else {
            if(color.color.a > 0) {
                color.color = new Color(255,255,255, color.color.a - 0.1f);
            }
        }
        //open the textbox
        if(Input.GetKeyDown(KeyCode.Z) && !textboxopen && a) {
            OpenTextBox();
        } else if(Input.GetKeyDown(KeyCode.Z) && textboxopen && currenttext == fulltext && framecount > -1) { //continue/close
            if(currentstring + 1 != lines.Length) {
                ContinueTextBox();
            } else {
                EndTextBox();
            }
        } else if(Input.GetKeyDown(KeyCode.Z) && textboxopen && currenttext != fulltext) { //skip
            currenttext = fulltext;
            currentletter = fulltext.Length;
        }
        //text box sound
        if(textboxopen) {
            texttext.maxVisibleCharacters = currenttext.Length;

            if(framecount == 2) {
                if(currenttext != fulltext) {
                    if(fulltext[currentletter].ToString() == ".") {
                        StartCoroutine(WaitFor(0.5f));
                    } else if(fulltext[currentletter].ToString() == "," || fulltext[currentletter].ToString() == ";" || fulltext[currentletter].ToString() == ":") {
                        StartCoroutine(WaitFor(0.25f));
                    } else {
                        framecount = 0;
                        currenttext = currenttext + fulltext.Substring(currentletter, 1);
                        ++currentletter;
                    }
                }
            } else {
                ++framecount;
            }

            if(currenttext == fulltext) {
                soundplaying = false;
                ArrowColor.color = new Color(255,255,255,1);
                if(ArrowAnimate.enabled == false) {
                    ArrowAnimate.enabled = true;
                    ArrowAnimate.Play("ArrowBlink", -1, 0);
                }
            } else if(ArrowColor.color != new Color(255,255,255,0) || ArrowAnimate.enabled == false) {
                ArrowColor.color = new Color(255,255,255,0);
                ArrowAnimate.enabled = false;
            }

            if(soundplaying) {
                textsound.enabled = true;
                if(textsound.volume != 1) {
                    textsound.volume += 0.2f;
                }
            } else {
                if(textsound.volume != 0) {
                    textsound.volume -= 0.2f;
                } else {
                    textsound.enabled = false;
                }
            }
        } else {
            if(textsound.volume != 0) {
                textsound.volume -= 0.2f;
            } else {
                textsound.enabled = false;
            }
        }
    }

    IEnumerator WaitFor(float seconds) {
        framecount = -seconds * 60;
        currenttext = currenttext + fulltext.Substring(currentletter, 1);
        soundplaying = false;
        yield return new WaitForSeconds(seconds);
        soundplaying = true;
        ++currentletter;
    }

    void OpenTextBox() {
        //set text and start it
        currenttext = "";
        textboxopen = true;
        currentletter = 0;
        currentstring = 0;
        fulltext = lines[currentstring];
        texttext.text = fulltext;
        textboxparent.SetActive(true);
        snap.clip = snapsound;
        snap.Play();
        soundplaying = true;
    }
    
    void ContinueTextBox() {
        ++currentstring;
        currentletter = 0;
        fulltext = lines[currentstring];
        currenttext = "";
        texttext.text = fulltext;
        snap.clip = snapsound;
        snap.Play();
        soundplaying = true;
    }

    void EndTextBox() {
        currentstring = 0;
        fulltext = "";
        currenttext = "";
        currentletter = 0;
        textboxparent.SetActive(false);
        textboxopen = false;
        snap.clip = clap;
        snap.Play();
        soundplaying = false;
    }

    void OnTriggerEnter(Collider fuck) {
        if(fuck.gameObject.name == "matador") {
            a = true;
            audio.Play();
        }
    }

    void OnTriggerExit(Collider fuck2) {
        if(fuck2.gameObject.name == "matador") {
            a = false;
        }
    }
}
