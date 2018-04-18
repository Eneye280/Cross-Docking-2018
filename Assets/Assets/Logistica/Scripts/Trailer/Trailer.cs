using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trailer : MonoBehaviour 
{
	[SerializeField] private Text texto_Trailer;
	//[SerializeField] private GameObject panelTrailer;
 	private void Start () 
	{
		StartCoroutine(TrailerSoftware());
	}

	IEnumerator TrailerSoftware()
	{
		yield return new WaitForSeconds(1f);
		texto_Trailer.text = "Bienvenidos";
		yield return new WaitForSeconds(2f);
		texto_Trailer.text = "Para el área de logística y transporte del Centro de Servicios y Gestion Empresarial";
		yield return new WaitForSeconds(2.5f);
		texto_Trailer.text = "es de gran importancia el buen manejo que se le debe dar al software de realidad virtual";
		yield return new WaitForSeconds(3f);
		//panelTrailer.GetComponent<RectTransform>().sizeDelta = new Vector2(55f,19.84f);
		texto_Trailer.text = "de entornos logisticos.";
		yield return new WaitForSeconds(3.1f);
		//panelTrailer.GetComponent<RectTransform>().sizeDelta = new Vector2(110,19.84f);
		texto_Trailer.text = "El desarrollo continúo y la fuerte penetración en la sociedad de la tecnología en general,";
		yield return new WaitForSeconds(4f);
		texto_Trailer.text = "y de los videojuegos en particular, es incuestionable.";
		yield return new WaitForSeconds(4.5f);
		texto_Trailer.text = "Y en este contexto, el uso de los videojuegos con fines educativos";
		yield return new WaitForSeconds(5f);
		texto_Trailer.text = "es un campo en auge en los ultimos años";

		yield return new WaitForSeconds(5.5f);
		//texto_Trailer.GetComponentInChildren<Text>().color = Color.red;
		texto_Trailer.text = "¿Cual es nuestro objetivo?";
		yield return new WaitForSeconds(6f);

		//texto_Trailer.GetComponentInChildren<Text>().color = Color.white;
		texto_Trailer.text = "Impactar de manera positiva en los aprendices del área de logística y transporte";
		yield return new WaitForSeconds(6.5f);
		texto_Trailer.text = "con escenarios simulados de realidad virtual en los procesos logísticos";
	}
}
