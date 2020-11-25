/*
 * Created by SharpDevelop.
 * User: janjie
 * Date: 24/11/2020
 * Time: 11:28 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Faculty.
	/// </summary>
	public class Faculty : Person 
	{
		public string SSSNumber {get; set;}
		public string Supervisor {get; set;}
	}
}
