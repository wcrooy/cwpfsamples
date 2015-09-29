In an attempt to help others use the Microsoft Patterns and Practices Composite WPF framework (formerly Prism) this project aims to provide samples relating to usage of the framweork.

All examples given within this project are not meant to be used as real world projects but server as an example of how to solve common and not so common problems within real world projects.

I've now migrated source and history from subversion to mercurial, follow [these instructions](http://code.google.com/p/cwpfsamples/source/checkout) to obtain the source.

## Late Night 0.4 Now Available ##

Well folks it's the first build of Late Night that I've made, and keeping with the samples name it's currently 4:50am while I write this. I hope you get a bit out of this application even it it's just a little. Please by all means let me know what you think. It's very similar to Product Prism, I wanted to rewrite Product Prism to remove references to the company I work for as you may already be aware of.

Some new features you will find that were not in Product Prism are

  * A new login screen that demonstrates how one might implement a login screen. Use _admin_ for the username and _pass_ for the password when the application starts up (this is written on the dialog itself).
  * A new splash screen demonstrating how one might show a borderless window with a progress bar and message text while the application starts. I haven't perfected this yet as I need a way for modules to register messages as they are starting up, the problem I'm facing is that modules must be started on the UI thread which is not practicle for sending messages to this dialog.
  * An about screen that can be found from _Help>About_ which demonstrates presenting IModule data for modules found from the applications IModuleEnumerator. I'd like to extend this further by getting some of the assembly information which could be useful in order to show the assembly version and an icon if it exists.
  * Document model has been enhanced to provide feedback via events for opening/closing documents, a cancellable event can be used while closing a document which will abandon a close operation.
  * Any System.Windows.FrameworkElement object can be used for a document view, it no longer needs to be a System.Windows.Controls.UserControl.
  * Tabs now have a close button with functionality that reflects the IE7 tabbed browsing mechanism.

A new use-case module has been used to replace the LinePlanModule from Product Prism. This new module represents a common "Notes" interface where notes can be created/deleted/edited. This module extends on the LinePlanModule by

  * Providing a better static service implementation
  * Providing a "New" command to create new notes.
  * Allowing a user to "Delete" a note.

I will be extending this module at a later date to provide user feedback by preventing a close if the note has not been saved. I will also provide a mechanism for notes to be serialized by a pluggable persistence mechanism (DB/WS/File).

![http://wiki.cwpfsamples.googlecode.com/hg/images/sample.png](http://wiki.cwpfsamples.googlecode.com/hg/images/sample.png)

### Notice ###
I'm working on a new project called LateNight, this project is a reiteration of ProductPrism but is a rewrite for several reasons, one being for the new Microsoft.Practices.Composite libraries for Composite WPF.

Late Night has a lot of new features that Product Prism doesn't, such as
  * **An about box**: that demonstrates how to present the user with currently loaded mosules
  * **A login screen**: demonstrating how and where you could present the user with a dialog asking for credentials.
  * **A splash screen**: Showing one possible way of handling a splash screen, this does not currently support feedback from other modules though I am looking at ways for this to be handled.

Check out the late night solution from the mercurial source repository.

## Mercurial Access ##
If you're new to mercurial and are wondering how to check-out the source-code take a look at [Mercurial](http://mercurial.selenic.com/).

## Looking for Support ##
I'd love to hear what others are doing, please feel free to communicate with me on the [issues section](http://code.google.com/p/cwpfsamples/issues/list) for any issues relating to the project or through the groups hosted at the [Composite WPF](http://www.codeplex.com/CompositeWPF) site for general Composite WPF discussion.

**Disclaimer**
_I "Brett Ryan", as the originator of this project am new to all areas of what this project is trying to acheive and hope that I can gather positive feedback and support on how I have solved some of the problems presented._