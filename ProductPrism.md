# Introduction #

ProductPrism was my first attempt at a project where I based most of my pattern and learning experience while coming to terms with Prism. ProductPrism will no longer feature further development as future goals will be acheived through LateNight and other new projects.


# Details #

ProductPrism covers the following use-cases

  * Module loading
  * Module abstraction through the bridge pattern interface contracts
  * Document presentation model with controller which could be thought of as a service
  * An implementation of Dan Crevier's DataModel-View-ViewModel concept http://blogs.msdn.com/dancre/archive/2006/10/11/datamodel-view-viewmodel-pattern-series.aspx
  * Example of how a message service might be used to allow pluggable user allert messaging. This is in a very basic form but the concept could be extended to implement MSN style alerts
  * Extension sites through the Composite WPF RevionManager method of extension site exposure
  * IE7 style menubar hiding
  * Simple example of a business service through the LinePlanModule by exposing a data service.

There are other useful components to this solution that can be reused in other applications such as the VersionHelper class that aids in getting version numbers for an application or turning the version of an assembly into the date the assembly was built.