# examRetakeScheduler
Instructor creates Exam Retake (time span) for certain students. This gets registered in the Datatase (MS SQL Server). Students receive email containing all the informaiton regarding the retake (class, instructor, dates and time).

![](examRetake.gif)

![](examRetake2.gif)

Students then need to schedule the retake.

![](examRetake3.gif)

All Users are forced to change the default password on first login. One-time authentication code is sent to the email address on file. Therefore implementing 2FA.

![](examRetake4.gif)

![](examRetake5.gif)

When studet comes in to complete the retake. The retake status gets updated to Completed, and the class instructr receives an email confirming the retake has been taken. 

![](examRetake6.gif)

Administrator can view all retakes, create new ones and delete/modify existing ones. 

![](examRetake7.gif)

Administrator can create/delete/modify users. When a new user role is created, an email containing all the information (credentials, role, responsibilities, etc.) is sent to the user. That user is then prompted to change the default password at first sign in. 

![](examRetake8.gif)
