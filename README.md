# Labs

These solutions holds different labs where I'm testing new coding techniques or new technologies, where I'm changing an existing solution I've most often already done in the Tutorials or Courses repo (which then most likely comes from Youtube, Udemy, or Pluralsight or similar). The reason is that I want to apply/test techniques I find better or techniques I want to test in conjunction with the demonstrated tutorial/course. This means that I take the finished solution from the tutorial or course repo and use it as a starting point for modification in my Labs repo. It could for instance be a Wpf-solution where the original solution holds code-behind (becuase the original example from the tutorial/course most likely is about demonstrating something else and code-behind was used for simplicity), and where I want to change to Mvvm, or maybe test the demonstrated tutorial/course with for instance Prism or CSLA etc. 

As opposed to the Sandbox repo, where there are very simple solutions with no folder structure and where the purpose is just to quickly test a given coding technique or technology, here you have the full folder structure as you would have in a normal full fledged Development repo/solution. 

### Solutions

1. MVVM Prism Services App using strictly Mvvm - Added 230804 
	- Solution is implemented in the Tutorials repo, based on the original tutorial on [YouTube](https://www.youtube.com/watch?v=S8hEjLahNtU&t=885s)
	- Original Tutorial name - Showing Dialogs in an MVVM Application with a Dialog Service (Prism)
	- Folder: Mvvm Prism Services App
	- Solution name: PrismServicesApp.sln
	- Framework: .Net 7.0
	- Purpose: To extend the original solution with pure Mvvm and no code-behind, and use Prism fully out. Possibly some extra functionality as well along the way.
 	- Outcome: MVVM fully supported. No Code-behind. Used behaviors instead of triggers to handle the event-triggering, thus the ViewModel is not breaking the MVVM way of doing things by referencing a View-specific object. Uses Prism. 

2. Wpf Dark Admin Panel with Prism and MVVM - Added 231030 
	- Original solution from [YouTube](https://www.youtube.com/watch?v=S8hEjLahNtU&t=885s)
	- Original Tutorial name - C# WPF UI | How to Design Dark Admin Panel in WPF
	- Folder: Dark Admin Panel
	- Solution name: DarkAdminPanel.sln
	- Framework: .Net 7.0
	- Purpose: To extend the original solution with some functionality, pure Mvvm and no code-behind, and use Prism fully out. Possibly some extra functionality as well along the way.
 	- Outcome: The application is in development.  

3. Desktop Contacts App - Added 231031 
	- Original solution from [Udemy](https://www.udemy.com/course/windows-presentation-foundation-masterclass/), chapter 6
	- Original Course name - Windows Presentation Foundation Masterclass
	- Folder: Desktop Contacts App
	- Solution name: DesktopContactsApp.sln
	- Framework: .Net 7.0
	- Purpose: To try different solutions and angles to the original presented solution, like extending the app to use no code-behind, use MVVM, use the Services concept etc.
 	- Outcome: Implemented the intended different angles/ways, to accomodate to MVVM and more. An ongoing project where possibly more techniques will be tested in the future. 

