/*
 * LinePlanExplorerDataModelTest.cs    7 June, 2008
 * 
 * Copyright 2008  All rights reserved.
 * Use is subject to licence terms.
 * 
 *  Author: Brett Ryan.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JohnSands.ProductPrism.Infrastructure;
using JohnSands.ProductPrism.LinePlanModule.BusinessEntities;
using JohnSands.ProductPrism.LinePlanModule.Services;
using JohnSands.ProductPrism.LinePlanModule.Views;


namespace LinePlanModule.Test {
    
    /// <summary>
    ///This is a test class for LinePlanExplorerDataModelTest and is intended
    ///to contain all LinePlanExplorerDataModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LinePlanExplorerDataModelTest {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void LinePlanExplorerDataModelTest1() {
            MockLinePlanService svc = new MockLinePlanService();
            //LinePlanExplorerDataModel model = new LinePlanExplorerDataModel(svc);
            
            //// Verify the initial model state
            //Assert.AreEqual(ModelState.Fectching, model.State);

            //DispatchHelper(model);

            //Assert.AreEqual(ModelState.Active, model.State);
            ////Assert.AreEqual(4, model.LinePlans.Count);
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        public void LinePlanExplorerDataModel_FailureTest() {
            FailingLinePlanService svc = new FailingLinePlanService();
            //LinePlanExplorerDataModel model = new LinePlanExplorerDataModel(svc);

            //// Verify the initial model state
            //Assert.AreEqual(ModelState.Fectching, model.State);

            //DispatchHelper(model);

            //Assert.AreEqual(ModelState.Invalid, model.State);
            //Assert.IsNull(model.LinePlans);
        }


        private void DispatchHelper(LinePlanExplorerModel model) {
            DispatcherFrame frame = new DispatcherFrame();

            PropertyChangedEventHandler waitForModelHandler = new PropertyChangedEventHandler(
                delegate(object sender, PropertyChangedEventArgs e) {
                    if (e.PropertyName == "State" && model.State != ModelState.Fectching) {
                        frame.Continue = false;
                    }
                });

            model.PropertyChanged += waitForModelHandler;

            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = new TimeSpan(0, 0, 10);
            tmr.Tag = frame;
            tmr.Start();
            tmr.Tick += new EventHandler(DoDispatcherHelperTimeout);
            Dispatcher.PushFrame(frame);

            if (tmr.Tag == null) {
                throw new TimeoutException("Timeout waiting for state change.");
            }
        }

        void DoDispatcherHelperTimeout(object sender, EventArgs e) {
            DispatcherTimer tmr = sender as DispatcherTimer;
            DispatcherFrame frame = tmr.Tag as DispatcherFrame;
            tmr.Stop();
            frame.Continue = false;
            tmr.Tag = null;
        }

    }

    class MockLinePlanService : ILinePlanService {
        #region ILinePlanService Members

        public ICollection<LinePlan> GetLinePlans() {
            System.Threading.Thread.Sleep(500);
            List<LinePlan> res = new List<LinePlan>();
            res.Add(new LinePlan() { LinePlanID = 1, Name = "Dummy 1t" });
            res.Add(new LinePlan() { LinePlanID = 1, Name = "Dummy 2t" });
            res.Add(new LinePlan() { LinePlanID = 1, Name = "Dummy 3t" });
            res.Add(new LinePlan() { LinePlanID = 1, Name = "Dummy 4t" });
            return res;
        }

        #endregion
    }

    class FailingLinePlanService : ILinePlanService {
        #region ILinePlanService Members

        public ICollection<LinePlan> GetLinePlans() {
            throw new NotImplementedException();
        }

        #endregion
    }

}
