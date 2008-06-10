/*
 * LinePlanExplorer.cs    6/5/2008 5:00:37 PM
 *
 * Copyright 2008  All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using JohnSands.ProductPrism.LinePlanModule.BusinessEntities;


namespace JohnSands.ProductPrism.LinePlanModule.Views {

    /// <summary>
    /// Interaction logic for LinePlanExplorer.xaml
    /// </summary>
    public partial class LinePlanExplorer : UserControl {

        /// <summary>
        /// Creates a new instance of <c>LinePlanExplorer</c>.
        /// </summary>
        /// <remarks>
        /// Almost everything needs to be moved back to the model, just need to
        /// figure out how to go about doing that.
        /// </remarks>
        public LinePlanExplorer(LinePlanExplorerModel model) {
            InitializeComponent();

            Model = model;
        }

        private LinePlanExplorerModel Model {
            get;
            set;
        }

        private void DoLinePlanDoubleClicked(object sender, EventArgs e) {
            ListBox s = sender as ListBox;
            if (s != null) {
                LinePlan lp = s.SelectedItem as LinePlan;
                if (lp != null) {
                    Model.OpenLinePlanCommand.Execute(lp);
                }
            }
        }

    }

}
