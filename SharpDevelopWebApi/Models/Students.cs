/*
 * Created by SharpDevelop.
 * User: janjie
 * Date: 24/11/2020
 * Time: 11:48 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Students.
	/// </summary>
	public class Students : Person1
	{
		public string SchoolLastAttended { get; set; }
		public int CourseId { get; set;}
	}
}
