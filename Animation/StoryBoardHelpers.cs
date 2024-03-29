﻿using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace NewProject
{
    /// <summary>
    /// Animation helpers
    /// </summary>
    public static class StoryBoardHelpers
    {
        /// <summary>
        /// add a slide from right animation to the storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance to the right to start from</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f,bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// add a slide from Left animation to the storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance to the left to start from</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f,bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// add fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance to the right to start from</param>
        /// <param name="decelerationRatio"></param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            storyboard.Children.Add(animation);
        }

        
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        
        public static void AddSlideToRight(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// add fade out animation to the storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance to the right to start from</param>
        /// <param name="decelerationRatio"></param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// add a slide from bottom animation to the storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance to the bottom to start from</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideFromBottom(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// add a slide to bottom animation to the storyboard
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance to the bottom to end at</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideToBottom(this Storyboard storyboard, float seconds, double offset,
            float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, keepMargin ? offset : 0, 0, -offset),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        #region Sliding To/From Top

        /// <summary>
        /// Adds a slide from top animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the top to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        /// <param name="keepMargin">Whether to keep the element at the same height during animation</param>
        public static void AddSlideFromTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide to top animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the top to end at</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        /// <param name="keepMargin">Whether to keep the element at the same height during animation</param>
        public static void AddSlideToTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f, bool keepMargin = true)
        {
            // Create the margin animate from right 
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, -offset, 0, keepMargin ? offset : 0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion

        /// <summary>
        /// Adds a marquee scrolling right to left animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="contentOffset">The inner contents size, to start the marquee as soon as that content has scrolled out of view</param>
        /// <param name="offset">The offset of the parent to scroll within</param>
        public static void AddMarquee(this Storyboard storyboard, float seconds, double offset = 0, double contentOffset = 0)
        {
            // Create the margin animate from right to left
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(-contentOffset, 0, contentOffset, 0),
                RepeatBehavior = RepeatBehavior.Forever
            };
            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }
    }
}
