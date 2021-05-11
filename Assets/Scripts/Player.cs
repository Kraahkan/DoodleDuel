using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {



    public Text healthDisplay;
    public GameObject losePanel;

    // STATS

    int numberOfJumps;
    int numberOfShots;

    // COMBAT (for it's own script soon)

    public string primaryAttackButton = "f";


    // INPUT

    public string jumpButton = "space";
    public string jumpButtonAlt = "w";
    public string leftButton;
    public string rightButton;
    public string shootButton;
    public string interactButton;

    // MOVEMENT

    [Range(0, 100)]
    public float playerSpeed = 1.1f;

    private float playerCurrentSpeed;

    [Range(0, 100)]
    public float playerInertia = 0f;

    [Range(0, 100)]
    public float playerJumpMult = 1.0f;

    [Range(0, 100)]
    public float playerGravity = 1.0f;

    private float currentSpeed;
    private bool isMoving; // potentially... = currentSpeed > 0;
    private bool isJumping; // potentially... = bottomCollision == false && currentSpeed > 0

    public float startDashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;

    // ATTRIBUTES

    public string playerName = "Gramma"; // to be displayed above their head in future?
    

    // This gives a slider in the Unity side of thigngs
    [Range(0, 10000)] 
    public float playerMaxHealth = 50;

    [Range(0, 10000)]
    private float playerCurrentHealth;

    public int playerArmour = 0;

    // COMBAT

    public float playerDamageMult = 1.0f;
     
    private bool isDamaged;

    // SOUND

    private string hitSounds = "";
    private string shootSounds = "";
    private string punchSound = "";
    private string walkSound = "";
    private string jumpSound = "";


    // PHYSICS

    Rigidbody2D rigidBody2D;

    // ANIMATION

    Animator animator;

    // MISC UNITY STUFF

    float input;

    // AUDIO

    public AudioSource hitSound;

    void Start()  // Start is called before the first frame update
    {

        getComponents();
        setAttributes();
        //setUI();

    }

    void setUI()
    {
        healthDisplay.text = playerCurrentHealth.ToString();
    }

    void setAttributes()
    {
        playerCurrentHealth = playerMaxHealth;

    }

    void getComponents()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //hitSound = GetComponent<AudioSource>(); this doesnt work for some reason??
    }

    private void FixedUpdate() // for physics
    {
        // check for key presses

        input = Input.GetAxis("Horizontal");
        
        // print(input); its smooth, not raw

        if (UnityEngine.Input.GetKeyDown("space"))
        {
           
            numberOfJumps++;
        }

        if (UnityEngine.Input.GetKeyDown(leftButton))
        {
            
        }

        if (UnityEngine.Input.GetKeyDown(rightButton))
        {

        }

        rigidBody2D.velocity = new Vector2(input * playerSpeed, rigidBody2D.velocity.y);

    }

    // Update is called once per frame
    void Update() // for animation
    {

        // ANIMATION

        if (input != 0)
        {
            animator.SetBool("playerIsRunning", true);
        }
        else { 
            animator.SetBool("playerIsRunning", false);
        } 

        if (input > 0) // right
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }

        if (input < 0) // left
        { 
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.V) && isDashing == false) // dash
        {
            playerSpeed += extraSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }

        if (dashTime <= 0 && isDashing == true)
        {
            isDashing = false;
            playerSpeed -= extraSpeed;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("grammaSword", true);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("grammaSword", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("grammaGun", true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("grammaGun", false);
        }



        // ACHIEVMENTS

        if (numberOfJumps > 1000)
        {
            // achievements!
        }

        if (playerMaxHealth - playerCurrentHealth < 25)
        {
            // Bloodied! bleeding?
        }

    }

    bool Walk()
    {
        return false;
    }


    bool Shoot()
    {
        return false;
    }


    public void TakeDamage(int dmg)
    {

        hitSound.Play();

        playerCurrentHealth -= dmg;
        if (playerCurrentHealth < 0)
            playerCurrentHealth = 0;

        healthDisplay.text = playerCurrentHealth.ToString();

        print("Player took " + dmg + " dmg, leaving them at: " + playerCurrentHealth);

        if (playerCurrentHealth <= 0)
        {
            Destroy(gameObject); // self
            losePanel.SetActive(true);
        }

    }

    bool isAlive()
    {
        if (playerCurrentHealth > 0)
            return true;
        else
            return false;
    }


    bool Jump()
    {
        return false;
    }


    void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "jump":
                break;
            case "walk":
                break;
            case "run":
                break;
            case "shoot":
                break;
            case "shotgun":
                break;
            case "pistol":
                break;
            default:
                break;
        }

    }

    void PlaySound(string soundName, int numberOfRepeats, int pitchRandomness)
    {

       
        string[] walkSounds = new string[] { };
        string[] hitSounds = new string[] { };

        int choose = Random.Range(0, 101);

        switch (soundName)
        {
            case "hit":
                break;
            default:
                break;

        }
    }

    
}

