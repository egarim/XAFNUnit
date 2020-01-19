;#DropDB XAFNUnitEasyTest

#Application XAFNUnitWin
#Application XAFNUnitWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef XAFNUnitWin

*Action About...
 
*Action OK

#EndIf

#IfDef XAFNUnitWeb
*Action Navigation(My Details)
#EndIf
