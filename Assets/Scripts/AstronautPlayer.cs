using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

	public class AstronautPlayer : MonoBehaviour {

		private Animator anim;
		private Rigidbody rb;
		public float radius = 2f;
		public int damage = 10, healPlayer = 10;
		public GameObject healText;
		private AudioSource m_AudioSource;
		public AudioClip steps, jump, hit;

		public float speed = 600.0f, jumpForce = 500f;
		public float turnSpeed = 400.0f;

		void Start () {
			rb = GetComponent <Rigidbody>();
			anim = gameObject.GetComponentInChildren<Animator>();
			m_AudioSource = GetComponent<AudioSource>();
		}

		void Update ()
		{
			if (PlayerHealth.death)
				return;

			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
			{
				anim.SetInteger("AnimationPar", 1);
				if (!m_AudioSource.isPlaying && rb.velocity.y == 0)
					PlayAudioPlayer(steps);
			}
			else
			{
				anim.SetInteger("AnimationPar", 0);
				if(m_AudioSource.isPlaying && m_AudioSource.clip == steps) m_AudioSource.Stop();
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

			DetectCollision();
		}

		void FixedUpdate()
		{
			if (PlayerHealth.death)
				return;
			
			if(rb.velocity.y == 0)
				anim.SetBool("IsJump", false);
			
			if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
			{
				rb.AddForce(Vector3.up * jumpForce);
				anim.SetTrigger("Jumping");
				anim.SetBool("IsJump", true);
				PlayAudioPlayer(jump);
			}
			
			float v = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
			rb.MovePosition(transform.position + transform.forward * v);
		}
		
		private void DetectCollision()
		{
			Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

			bool foundEnemyToHeal = false;
			foreach (var el in hitColliders)
			{
				if (el.CompareTag("Enemy") && Input.GetMouseButtonUp(0))
				{
					anim.SetTrigger("IsAttack");
					el.GetComponent<EnemyHealth>().TakeDamage(damage);
					PlayAudioPlayer(hit);
				}

				if (el.CompareTag("Enemy") && el.GetComponent<EnemyHealth>().death 
				                           && el.GetComponent<EnemyHealth>().isCanHeal)
				{
					if (Input.GetKeyUp(KeyCode.I))
					{
						GetComponent<PlayerHealth>().Heal(healPlayer);
						el.GetComponent<EnemyHealth>().isCanHeal = false;
					}

					foundEnemyToHeal = true;
					
					if(!healText.activeSelf) healText.SetActive(true);
				} 
				
				if(!foundEnemyToHeal && healText.activeSelf) healText.SetActive(false);
			}
		}
		void PlayAudioPlayer(AudioClip clip)
		{
			m_AudioSource.loop = clip == steps;

			m_AudioSource.Stop();
			m_AudioSource.clip = clip;
			m_AudioSource.Play();
		}
	}
	
	
}





