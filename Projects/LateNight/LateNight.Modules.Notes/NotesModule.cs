/*
 * NotesModule.cs    6/16/2008 5:07:47 PM
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

using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Unity;

using BrettRyan.LateNight.Constants;
using BrettRyan.LateNight.DocumentModel;
using BrettRyan.LateNight.Modules.Notes.Services;
using BrettRyan.LateNight.Modules.Notes.Views;


namespace BrettRyan.LateNight.Modules.Notes {

    /// <summary>
    ///
    /// </summary>
    [Module(ModuleName="Late Night Notes Module", StartupLoaded=true)]
    public class NotesModule : IModule {

        private readonly IUnityContainer container;
        private readonly IDocumentController systemDocumentController;

        /// <summary>
        /// Creates a new instance of <c>NotesModule</c>.
        /// </summary>
        public NotesModule(IUnityContainer container) {
            this.container = container;
            systemDocumentController = container.Resolve<IDocumentController>(
                ControllerNames.SystemDocumentController);
        }


        #region IModule Members

        public void Initialize() {
            container.RegisterType<INoteService, StaticNoteService>(
                // This will register the type as a singleton instance.
                new ContainerControlledLifetimeManager());
            container.RegisterType<NotesBrowserModel>(
                new ContainerControlledLifetimeManager());

            INoteService noteService = container.Resolve<INoteService>();

            NotesBrowserModel model = container.Resolve<NotesBrowserModel>();
            systemDocumentController.OpenDocument(model);
        }

        #endregion

    }

}
