﻿using RURS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ModelLibary.Models;
using RURS.Persistency;

namespace RURS.Handler
{
    class FaerdigvareKontrolHandler
    {
        public FaerdigvareKontrolViewModel FaerdigvareKontrolViewModel { get; set; }
        
        
        public FaerdigvareKontrolHandler(FaerdigvareKontrolViewModel faerdigvareKontrolViewModel)
        {
            FaerdigvareKontrolViewModel = faerdigvareKontrolViewModel;
        }

        public async void LoadFKontrol()
        {
            int processOrdreNr = Model.SelectedPOSingleton.GetInstance().ActiveProcessOrdre.ProcessOrdreNr;
            
            FaerdigvareKontrol loadedFK = await PersistencyFaerdigvareKontrol.GetFaerdigvareKontrol(processOrdreNr);
            FaerdigvareKontrolViewModel.NyFaerdigvareKontrol = loadedFK;
            

        }


        /*
        //forskellige iterationer der er gemt for at jeg kan holde styr på min tanke række
        
        public async void LoadFKontrol()
        {
            int processOrdreNr = Model.SelectedPOSingleton.GetInstance().ActiveProcessOrdre.ProcessOrdreNr;
            
            FaerdigvareKontrol loadedFK = await PersistencyFaerdigvareKontrol.GetFaerdigvareKontrol(processOrdreNr);
            /*
            int faerdigvareNr = loadedFK.FaerdigvareNr;
            string faerdigvareNavn = loadedFK.FaerdigvareNavn;
            int laagNr = loadedFK.LaagNr;
            int daaseNr = loadedFK.DaaseNr;
            int multipackNr = loadedFK.MultipackNr;
            int kartonNr = loadedFK.KartonNr;
            int palleNr = loadedFK.PalleNr;
            ///
        //FaerdigvareKontrol loadedFKontrol = new FaerdigvareKontrol();
        //loadedFKontrol = loadedFK;
        //FaerdigvareKontrolViewModel.NyFaerdigvareKontrol = loadedFK;
        //FaerdigvareKontrol aFaerdigvareKontrol = new FaerdigvareKontrol();
        //PersistencyFaerdigvareKontrol pFaerdigvareKontrol = new PersistencyFaerdigvareKontrol();

        }
        */
    }
}
