using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankManeger : MonoBehaviour
{
	[SerializeField] float m_ValorInicial = 0f;

	[SerializeField] GameObject m_PanelSacar;
	[SerializeField] GameObject m_PanelDepositar;
	[SerializeField] GameObject m_PanelSaldo;
	[SerializeField] Text m_TextSaldo;
	[SerializeField] InputField m_IFSacar;
	[SerializeField] InputField m_IFDepositar;
	[SerializeField] float m_SaldoAtual;
	[SerializeField] float m_ValorDigitado = 0f;
	const string KEY_SALDO = "key_saldo"; 

	void Awake()
	{
		if(m_PanelSacar) { m_PanelSacar.SetActive(false); }
		if(m_PanelDepositar) { m_PanelDepositar.SetActive(false); }
		if(m_PanelSaldo) { m_PanelSaldo.SetActive(false); }

		m_SaldoAtual = PlayerPrefs.GetFloat(KEY_SALDO, m_ValorInicial); //Recupera o valor salvo no PC/Celular
	}




	public float GetSaldoAtual()
	{
		m_SaldoAtual = PlayerPrefs.GetFloat(KEY_SALDO, m_ValorInicial);
		return m_SaldoAtual;
	}
	public void SetSaldoAtual(float value)
	{
		PlayerPrefs.SetFloat(KEY_SALDO, value);
		m_SaldoAtual = GetSaldoAtual();
	}



	public void CampoSacar(string value)
	{
		m_ValorDigitado = float.Parse(value);
	}
	public void CampoDepositar(string value)
	{
		m_ValorDigitado = float.Parse(value);
	}



	public void OnClickSacar()
	{
		if(m_PanelSacar) { m_PanelSacar.SetActive(true); }
		if(m_PanelDepositar) { m_PanelDepositar.SetActive(false); }
		if(m_PanelSaldo) { m_PanelSaldo.SetActive(false); }
	}
	public void OnClickDeposisar()
	{
		if(m_PanelSacar) { m_PanelSacar.SetActive(false); }
		if(m_PanelDepositar) { m_PanelDepositar.SetActive(true); }
		if(m_PanelSaldo) { m_PanelSaldo.SetActive(false); }
	}
	public void OnClickSaldo()
	{
		if(m_PanelSacar) { m_PanelSacar.SetActive(false); }
		if(m_PanelDepositar) { m_PanelDepositar.SetActive(false); }
		if(m_PanelSaldo) { m_PanelSaldo.SetActive(true); }

		if(m_TextSaldo) { m_TextSaldo.text = "$ " + GetSaldoAtual().ToString(); } //Atualiza a UI Text, com o valor do Saldo atual
	}


	
	public void OnClickConfirmarSacar()
	{
		if(m_IFSacar) { m_ValorDigitado = float.Parse(m_IFSacar.text); }

		if(m_ValorDigitado < 0) { m_ValorDigitado *= -1; } //se o valor for negativo converte para positivo

		if (m_ValorDigitado <= m_SaldoAtual)
		{
			SetSaldoAtual(m_SaldoAtual - m_ValorDigitado); //Subtrai do Saldo atual
			if(m_PanelSacar) { m_PanelSacar.SetActive(false); }
		}
		else
		{
			if(m_PanelSacar) { m_PanelSacar.SetActive(false); }
		}
	}
	public void OnClickConfirmarDepositar()
	{
		if(m_IFSacar) { m_ValorDigitado = float.Parse(m_IFDepositar.text); }

		if(m_ValorDigitado < 0) { m_ValorDigitado *= -1; } //se o valor for negativo converte para positivo

		if (m_ValorDigitado > 0)
		{
			SetSaldoAtual(m_SaldoAtual + m_ValorDigitado); //Soma ao Saldo atual
			if(m_PanelDepositar) { m_PanelDepositar.SetActive(false); }
		}
		else
		{
			if(m_PanelDepositar) { m_PanelDepositar.SetActive(false); }
		}
	}
	public void OnClickVoltarSaldo()
	{
		if(m_PanelSaldo) { m_PanelSaldo.SetActive(false); }
	}
}
