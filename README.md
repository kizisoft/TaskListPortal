# TaskListPortal

I prefer  ”Code First” modeling workflow because:

-	 It allows full control over the code. There is no code that is automatically generated.
-	There is no need to create partial classes when something doesn’t have to be in the database. Data annotations can be used instead.
-	It’s easy to manage database version control using automatic migrations.

Why we need dependency injector:
-	Classes should declare what they need 
-	Constructors should require dependencies 
-	Hidden dependencies should be shown 
-	Dependencies should be maximum abstract, that’s why we use interfaces instead of concrete classes. 

 I prefer  Ninject dependency injector because:
-	With it declaration of data bindings is very easy and compact.
-	No need of complex configuration in additional xml files.

Why to use view models in the presentation layer and not directly the business data:
-	Remove logic from the presentation layer
-	Security
-	Loose coupling

I use AutoMapper because:
-	It is an easy way to map business objects and view models
