/*
 * NotesBrowser.cs    6/16/2008 9:29:03 PM
 *
 * Copyright 2008 Brett Ryan All rights reserved.
 * Use is subject to license terms
 *
 * Author: Brett Ryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BrettRyan.LateNight.Modules.Notes.Entities;


namespace BrettRyan.LateNight.Modules.Notes.Views {

    /// <summary>
    /// Interaction logic for NotesBrowser.xaml
    /// </summary>
    public partial class NotesBrowser : UserControl {

        /// <summary>
        /// Creates a new instance of <c>NotesBrowser</c>.
        /// </summary>
        public NotesBrowser(NotesBrowserModel model) {
            InitializeComponent();

            Model = model;
        }

        private NotesBrowserModel Model {
            get;
            set;
        }

        private void DoNoteDoubleClicked(object sender, MouseButtonEventArgs e) {
            Selector sel = sender as Selector;
            if (sel != null) {
                Note note = sel.SelectedItem as Note;
                if (note != null) {
                    Model.OpenNoteCommand.Execute(note);
                }
            }
        }

    }

}
