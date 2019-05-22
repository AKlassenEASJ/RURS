﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;
using RURS.Common;
using RURS.Handler;
using RURS.Model;

namespace RURS.ViewModel
{
    class BemandingViewModel : VMBase
    {
        #region InstanceFields

        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private Bemanding _nyBemanding = new Bemanding();
        private ICommand _addCommand;
        private ICommand _validateEmployeesCommand;
        private ICommand _validateBreaksCommand;
        private Dictionary<string, FejlTjek> _validations;


        #endregion

        #region Properties

        public TimeSpan StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value; 
                OnPropertyChanged();
            }
        }

        public TimeSpan EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value; 
                OnPropertyChanged();
            }
        }

        public Bemanding Bemanding
        {
            get { return _nyBemanding; }
            set
            {
                _nyBemanding = value; 
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public ICommand ValidateEmployeesCommand
        {
            get {return _validateEmployeesCommand;}
            set { _validateEmployeesCommand = value; }
        }

        public ICommand ValidateBreaksCommand
        {
            get { return _validateBreaksCommand; }
            set { _validateBreaksCommand = value; }
        }

        public Dictionary<string, FejlTjek> Validations
        {
            get { return _validations; }
            set { _validations = value; }
        }

        public BemandingHandler BemandingHandler { get; set; }


        #endregion

        #region Constructor

        public BemandingViewModel()
        {
            BemandingHandler = new BemandingHandler(this);
            _addCommand = new RelayCommand(BemandingHandler.AddAsync);
            
            
            _startTime = DateTime.Now.TimeOfDay;
            _endTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(01, 00, 00));
            
        }


        #endregion

        #region Methods



        #endregion

        #region HelpMethods

        private void AddValidations()
        {
            _validations.Add("Medarbejdere", new FejlTjek());
            _validations.Add("Pauser", new FejlTjek());
        }

        #endregion

    }
}
