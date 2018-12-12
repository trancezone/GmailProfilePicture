# GmailProfilePicture

GmailProfilePicture is Xamarin.Android assembly containing  Android view implementing a default Gmail Profile Picture. The picture consists of one circle filled with color and assigned text.

# Usage

To use the view inside your project, a following steps needs to be done:
 1. An assembly Librarian.GmailProfilePicture needs to be added to your Visual Studio projects 
 2. Inside your activity's XML add a line as follow one:
 
 ```
 
 <techiix.android.views.GmailProfilePicture
        android:id="@+id/profile_pic"
        gmail_profile:radius="20"
        gmail_profile:text_size="24"
        gmail_profile:display_text="ES"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:layout_alignParentLeft="true"
        android:layout_centerVertical="true"
        android:layout_marginRight="16dp" /> 
      
 ```
 
# Limitations
 - A text inside the circle is always white
 - The collor pallet is predefined in this version

# FAQ

#### What is the project 'GmailProfilePicture Assembly'  for?

This project produces the Xamarin.Android assembly containing the view.

#### What  is minimum Android version  required for the view?

The project 'GmailProfilePicture Assembly' project is compiled using Android version 5.1

#### What is the project ToTestAssembly for?

Already prepared Xamarin.Android Visual Studio project, you can use to test the view without need to create your own.

#### What is it the folder Architecture for?

The folder represents the Modelio workspace containing UML diagrams of the view. The goal is to promote good software engineering techniques and methodologies in practice.
Modelio can be downloaded from https://www.modelio.org/downloads/download-modelio.html