# PPLInk
Provides a link to MS PowerPoint to simplify presentation of a selection of files listed in an SQL database

This Windows-only application is a simplified version of Projection Helper (ProHelp).  This version provides a screen on which the user can search the database and create a temporary playlist that can be used to show a selection of PowerPoint files using just the Next/Previous/Black/White keys. The main purpose of PPLink is to avoid the use of Windows Explorer to find the files on disk thus avoiding mistakes that can delete or move files.  It also enhances the poresentation by automatically advancing to the next file.

The application includes tools to create and fill the database from a collection of PowerPoint files contained in a set of folders named by a single alphabetic character.  PPLink uses only table T_FILES which needs to have the following columns:
* file_no (integer) - primary key<br>
* f_name (varchar 80) - the exact name of the presentation file on disk<br>
* f_altname (varchar 80) - an alternative name for the content for searching<br>
* f_path (varchar 250) - the full location of the folder<br>
* selected (char 1) - if 'Y', this file is on the short list - PPLink doesn't use the short list<br>
* create_dt (datetime) - the date the record was inserted in the table<br>
* last_dt (datetime) - the last date that the record was changed, NULL if no changes have been made<br>
* last_action (varchar 30) the nature of the last update - inserted by maintenance routines, not accessible to the user<br>
* inactive (char 1) - if 'Y', the record is ignored by the application

By providing an SQL database containing a matching table with your own fill methods and ignoring the FILL setup in PPLink, you could use it for a different arrangement of file storage. Other tables in the database are for building and using a set of saved playlists.  These are only used in ProHelp.  It is planned to add ProHelp to GitHub in the near future.
