﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;


namespace Currency_Info.ViewModels
{
    class RegionCurrencies : ViewModelBase
    {
        public Region region;

        public RegionCurrencies(Region region, MainViewModel.DictionaryRegion<string, string> iDBanksOrExchangers)
        {
            foreach (var item in iDBanksOrExchangers)
            {
                foreach (var items in item.Value)
                {
                    if (items == region.ID)
                    {
                        this.region = region;
                    }
                }
            }
        }

        public string Region
        {
            get
            {
                try
                {
                    if (region == null)
                    {
                        throw new Exception();
                    }
                    return region.Title;
                }
                catch
                {
                    return new Region().Title = null;
                }

            }
            set
            {
                region.Title = value;
                OnPropertyChanged();
            }
        }
    }
}
