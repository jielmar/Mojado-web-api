/*
 * Created by SharpDevelop.
 * User: janjie
 * Date: 16/11/2020
 * Time: 3:14 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Song.
	/// </summary>
	public class Song
	{
		public int Id { get; set; }
        public String Title { get; set; }
        public string Artist { get; set; }
        public String Genre{ get; set; }
	}
}
