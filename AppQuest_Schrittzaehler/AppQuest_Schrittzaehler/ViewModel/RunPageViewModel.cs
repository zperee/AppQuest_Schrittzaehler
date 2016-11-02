﻿using System;
using AppQuest_Schrittzaehler.Infrastructure;
using AppQuest_Schrittzaehler.Model;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler
{
	public class RunPageViewModel
	{
		MyScanner _scanner;
		Route _route; 
		FileSaver _fileSaver;

		public RunPageViewModel(Route route) {
			_scanner = new MyScanner();
			_route = route; 
			_fileSaver = new FileSaver(null, null);
		}

		public ContentPage ScanButton_OnClicked()
		{
			 return _scanner.ScanQrCode();
		}

		public void AddStepButton_OnClicked(){
			
		}


	}
}
