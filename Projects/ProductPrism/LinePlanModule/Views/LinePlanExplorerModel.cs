/*
 * LinePlanExplorerDataModel.cs    6/6/2008 5:22:09 PM
 *
 * Copyright 2008  All rights reserved.
 * Use is subject to license terms
 *
 * Author: bryan
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

using Microsoft.Practices.Unity;

using Prism.Commands;

using JohnSands.ProductPrism.Infrastructure;
using JohnSands.ProductPrism.Infrastructure.Constants;
using JohnSands.ProductPrism.LinePlanModule.BusinessEntities;
using JohnSands.ProductPrism.LinePlanModule.Services;


namespace JohnSands.ProductPrism.LinePlanModule.Views {

    /// <summary>
    /// Data model representing the line-plan explorer.
    /// </summary>
    public class LinePlanExplorerModel : AbstractDocument {

        private UserControl view;
        private ILinePlanService service;
        private IDocumentController documentController;

        /// <summary>
        /// Creates a new instance of <c>LinePlanExplorerDataModel</c>.
        /// </summary>
        public LinePlanExplorerModel(IUnityContainer container) {
            OpenLinePlanCommand = new DelegateCommand<LinePlan>(
                OpenLinePlan, CanOpenLinePlan);

            view = new LinePlanExplorer(this);
            service = container.Resolve<ILinePlanService>();
            documentController = container.Resolve<IDocumentController>(
                ControllerNames.DocumentController);

            //State = ModelState.Fectching;
            //if (!ThreadPool.QueueUserWorkItem(new WaitCallback(FetchLinePlans))) {
            //    State = ModelState.Invalid;
            //}
            LinePlans = new ObservableCollection<LinePlan>();
            LoadAllLinePlans();
        }

        /// <summary>
        /// Command which will open a line-plan as a line-plan editor
        /// </summary>
        public DelegateCommand<LinePlan> OpenLinePlanCommand {
            get;
            private set;
        }

        /// <summary>
        /// List of available line-plans a user may select from.
        /// </summary>
        public ObservableCollection<LinePlan> LinePlans {
            get;
            private set;
        }

        /// <summary>
        /// Clears the line-plan list and reloads it fromt he database.
        /// </summary>
        public void LoadAllLinePlans() {
            LinePlans.Clear();
            ICollection<LinePlan> res = service.GetLinePlans();
            foreach (LinePlan lp in res) {
                LinePlans.Add(lp);
            }
        }


        private void OpenLinePlan(LinePlan lp) {
            if (lp == null) {
                return;
            }

            documentController.OpenDocument(new LinePlanEditorModel(lp));
            //OnOpenLinePlan(new DataEventArgs<OrderPresentationModel>(this));
        }

        private bool CanOpenLinePlan(object arg) {
            return true;
        }

        //private void FetchLinePlans(object state) {
        //    IList<LinePlan> fetchedLinePlans;
        //    try {
        //        fetchedLinePlans = Service.GetLinePlans();
        //        Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
        //            new ThreadStart(delegate {
        //                this.LinePlans.Clear();
        //                foreach (LinePlan lp in fetchedLinePlans) {
        //                    this.LinePlans.Add(lp);
        //                }
        //                this.State = ModelState.Active;
        //            }));
        //    } catch (Exception) {
        //        Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
        //            new ThreadStart(delegate {
        //                this.State = ModelState.Invalid;
        //            }));
        //    }
        //}


        public override string DocumentTitle {
            get { return "Line Plans"; }
        }

        public override UserControl View {
            get { return view; }
        }

        public override string Description {
            get { return "Browse and/or search for line-plans"; }
        }

    }

}
