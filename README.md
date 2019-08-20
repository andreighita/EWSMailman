# EWSMailman
EWS Utility for mailbox operations. 

![alt text](https://github.com/andreighita/EWSMailman/blob/master/ReadME/EwsMailman.PNG?raw=true)

# Setting up the service

The Options form displays automatically after the main form is displayed. The options are as follows:

## Endpoint options

**Use autodiscover**: Enable this radio button to allow the discovery of the EWS service URL by means of the autodiscover service. In order for this to work, the DNS settings of your domain need to be correct and the autodiscover server needs to be accessible from the client machine.

**Use service URI**: Enable this radio button in order to specify the **EWS URL** value manually if you know which service to connect to. This is usually in the form of https://SERVER_DNS_NAME/ews/exchange.asmx, where is the same server address as the one used to access Outlook Web App (OWA).

## Credentials

**Use default credentials**: Check this checlbox in order to access the server as the currently logged on user. This option can only be used if you're running a local (on-prem) installation of Exchange Server. 

**Username**: The User Principal Name (UPN) of the user to connect as. 

**Password**: The password of the user to connect as. 

## Service Options

**Exchange Version**: Slect the appropriate value based on the Exchange Server version you are running. The version doesn't have to match your server version exactly. If you can't find your server version in the list, select the closest inferior version you can find in the list. If the mailbox is hosted in Office 365 Exchange Online, select the highest value available in the list. 

**Impersonate email**: Check this checkbox if you're connecting using an account that has been assigned the ApplicaitonImpersonation role and you are using that account to access other mailboxes using EWS Impersonation. If you check this checkbox, you must specify the e-mail address of the mailbox to access in the text field adjacent to the checkbox name. If you're accessing the mailbox of the user whose credentials you've specified above, leave the *Impersonate email* checkbox unchecked. 

If the mailbox auto discovery fails, please specify the EWS url instead. 
![alt text](https://github.com/andreighita/EWSMailman/blob/master/ReadME/Options.PNG?raw=true)

# Exporting items

To export items using EWS click on the **Export Items** button in the main form. 

The form will take a bit of time to load as it will loop through the folders in the mailbox and display the folder hierarchy in the tree view on the left. 

Once the folders tree is loaded, expand it and navigate to the folder that contains the item you wish to export. Select the folder containing the item you wish to export and make sure the folder name and folder Id are displayed in the **Folder name** and **Folder Id** fields.

When you select the folder, the panel on the right will start populating the list of items and will display the **DateTimeReceived** and **Subject** columns. 

Select the item you wish to export from the list by clicking on the **DateTimeReceived** row corresponding to the item, and click the **Export** button. 

If you wish to export the item to a folder other than the current directory from which you are running the executable, please click the **Browse** button and select the folder you wish to export the item in.

A message box will be fisplayed confirming the export. 

![alt text](https://raw.githubusercontent.com/andreighita/EWSMailman/master/ReadME/ExportForm.PNG)

# Importing items

To import items using EWS click on the **Import Items** button in the main form. 

The form will take a bit of time to load as it will loop through the folders in the mailbox and display the folder hierarchy in the tree view on the left. 

Once the folders tree is loaded, expand it and navigate to the folder in which you wish to import items previously exported. Select the folder and make sure the folder name and folder Id are displayed in the **Folder name** and **Folder Id** fields, then click on the **Import** button to browse to the previously exported item and import that intem into the selected folder.

When the import completes a message box will be displayed showing the ResponseCode received form the service. 

![alt text](https://github.com/andreighita/EWSMailman/blob/master/ReadME/ImportForm.PNG?raw=true)
