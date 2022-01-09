﻿using NewProject.Core;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NewProject
{
    /// <summary>
    /// the base page for all pages to gain base functionality
    /// </summary>
    public class BasePage : UserControl
    {
        #region Public Properties

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.55f;

        /// <summary>
        /// a flag to indicate if this page should animate out on load
        /// when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        #endregion


        #region Constructor

        public BasePage()
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;


            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }


            Loaded += BasePage_Loaded;
        }

        #endregion


        #region Animation Load or Unload


        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    //Start the animation
                    await this.SlideAndFadeInFromRight(SlideSeconds,width: (int)Application.Current.MainWindow.Width);

                    break;
                default:
                    Debugger.Break();
                    break;
            }
        }
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            //if we are setup to animate ot on load
            if (ShouldAnimateOut)
            {
                await AnimateOut();
            }
            else
            {
                await AnimateIn();
            }
        }



        public async Task AnimateOut()
        {
            if (PageUnloadAnimation == PageAnimation.None) return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    //Start the animation
                    await this.SlideAndFadeOutToLeft(SlideSeconds);

                    break;
            }
        }

        #endregion
    }

    public class BasePage<VM> : BasePage
        where VM:BaseViewModel,new()

    {

        #region Private menber

        private VM _viewModel;

        #endregion


        #region Public Properties

        /// <summary>
        /// the view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => _viewModel; 
            set
            {
                if (_viewModel == value) return;

                _viewModel = value;

                //set the data context for this page
                DataContext = _viewModel;
            }
        }

        #endregion


        #region Constructor

        public BasePage() : base()
        {
            //default view model
            ViewModel = new VM();
        }

            #endregion
    }
}
