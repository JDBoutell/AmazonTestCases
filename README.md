# AmazonTestCases
Basic Test Cases for Amazon site

I used NUnit and Selenium to run this using ReSharper.  They should be runnable in Visual Studio, I was using 
VS 2015 in case that makes a difference.

Be sure to change the private variables in CartSmokeTest, that dictates where the screenshot goes.

NOTE: There seems to be some weird case where the amazon pages load differently than normal.  Don't know why, maybe
they are testing something on select users.  But certain elements and ids change if it loads the other way and the 
test will fail.  They do pass the majority of the time, there is just this hiccup which I don't understand at the moment.

