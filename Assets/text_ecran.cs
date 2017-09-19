using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_ecran : MonoBehaviour {

	private TextMeshPro m_textMeshPro;
	// Use this for initialization
	IEnumerator Start () {
		m_textMeshPro = gameObject.GetComponent<TextMeshPro> () ?? gameObject.AddComponent<TextMeshPro> ();

		int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount;
		int counter = 0;

		while (true) {
			int visibleCount = counter % (totalVisibleCharacters + 1);

			m_textMeshPro.maxVisibleCharacters = visibleCount;

			if (visibleCount >= totalVisibleCharacters)
				yield return new WaitForSeconds (1.0f);

			counter += 1;

			yield return new WaitForSeconds (0.05f);
		}
	}

}
