﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ILSpyVisualizer.Infrastructure;
using System.Windows.Input;

namespace ILSpyVisualizer.AssemblyBrowser.ViewModels
{
	class GroupedUserCommand : ViewModelBase
	{
		private bool _isCurrent;

		public GroupedUserCommand(string text, Action action, bool isCurrent)
			: this(text, action)
		{
			_isCurrent = isCurrent;
		}

		public GroupedUserCommand(string text, Action action)
		{
			Text = text;
			Command = new DelegateCommand(() =>
			                              	{
												ClearCurrentCommand();
			                              		IsCurrent = true;
			                              		action();
			                              	});
		}

		public string Text { get; private set; }
		public ICommand Command { get; private set; }
		
		public bool IsCurrent
		{
			get { return _isCurrent; }
			set
			{
				_isCurrent = value;
				OnPropertyChanged("IsCurrent");
			}
		}

		public CommandsGroupViewModel GroupViewModel { get; set; }

		private void ClearCurrentCommand()
		{
			GroupViewModel.ClearCurrentCommand();
		}
	}
}
