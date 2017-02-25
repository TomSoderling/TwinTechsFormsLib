﻿using System;

using Xamarin.Forms;
using TwinTechs.Example;
using TwinTechs.Example.GridView;

namespace TwinTechs
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
//			MainPage = new GridViewOptions ();
//			MainPage = new GridViewPerformance2 ();
			MainPage = new NavigationPage (new SampleMenu ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

