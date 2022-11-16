import os, sys, shutil, ctypes, logging, webbrowser, winreg; from threading import Timer; import tkinter as tk;

class App(tk.Tk):
    def __init__(self, *args, **kwargs):
        tk.Tk.__init__(self, *args, **kwargs)

        #Vars
        self.appName = "AutoSortFolder"
        self.sortingMethod = ""
        self.currentPage = "MainPage"

        #Colors
        self.bgColor = "#abb1eb"
        self.titleColor = "black"
        self.textColor = "black"
        self.buttonColor = "white"
        self.buttonTextColor = "black"
        self.buttonPressedColor = "grey"

        #Fonts
        self.titleFont = ("Cascadia Code Semibold", 35)
        self.creditsTitleFont = ("Cascadia Code Semibold", 15)
        self.creditsFont = ("Cascadia Code Regular", 13)
        self.textFont = ("Cascadia Code Light", 12)
        self.buttonTextFont = ("Cascadia Code Light", 8)

        #Window Configuration
        self.configure(bg=self.bgColor)
        self.resizable(False, False)
        self.grid_anchor("center")
        self.geometry("600x425")
        self.title("AutoSorterFolder")

        #Stack Container Frame
        container = tk.Frame(self)
        container.configure(bg=self.bgColor)
        container.grid(column=0, row=0)
        container.grid_anchor("center")
        container.grid_rowconfigure(0, weight=1)
        container.grid_columnconfigure(0, weight=1)

        self.frames = {}
        for F in (MainPage, CreditsPage):
            page_name = F.__name__
            frame = F(parent=container, controller=self)
            self.frames[page_name] = frame
            frame.grid(row=0, column=0, sticky="nsew")

        self.show_frame("MainPage")

    def show_frame(self, page_name):
        '''Show a frame for the given page name'''
        frame = self.frames[page_name]
        frame.tkraise()
    
    def destroy_window(self):
        self.destroy()

    def alphabetical(self):
        self.sortingMethod = "alphabet"
        self.destroy_window()

    def extension(self):
        self.sortingMethod = "extension"
        self.destroy_window()

    def custom(self):
        self.sortingMethod = "custom"
        self.destroy_window()

    def credits_toggle(self):
        if self.currentPage == "MainPage":
            self.show_frame("CreditsPage")
            self.currentPage = "CreditsPage"
        else:
            self.show_frame("MainPage")
            self.currentPage = "MainPage"

    def add_to_registry(self):
        directoryPath = os.path.dirname(os.path.realpath(__file__))
        fileName = self.appName + ".exe"
        filePath = f'"{directoryPath}\{fileName}"'

        #Registry
        key = winreg.HKEY_CURRENT_USER
        key_value = "Software\Microsoft\Windows\CurrentVersion\Run"
        openKey = winreg.OpenKey(key, key_value, 0, winreg.KEY_ALL_ACCESS)
        winreg.SetValueEx(openKey, self.appName, 0, winreg.REG_SZ, filePath)
        winreg.CloseKey(openKey)

class MainPage(tk.Frame):
    def __init__(self, parent, controller):
        tk.Frame.__init__(self, parent)
        self.controller = controller

        #Functions
        def auto_run_toggle():
            if autoRunVar.get() == True:
                print("Added to registry")
                controller.add_to_registry()
        
        #Color BG
        self.configure(bg=controller.bgColor)

        #Vars
        autoRunVar = tk.BooleanVar()
        autoRunVar.set(False)

        #Widgets
        titleFrame = tk.Frame(self, borderwidth=4, relief="solid")
        titleLabel = tk.Label(titleFrame, text=controller.appName, font=controller.titleFont, fg=controller.titleColor)
        versionLabel = tk.Label(titleFrame, text="v1.0.0")
        spacerFrame_1 = tk.Frame(self, height=50, bg=controller.bgColor)
        autoRunToggle = tk.Checkbutton(self, text="Auto-Start On Boot", variable=autoRunVar, command=auto_run_toggle)
        methodFrame = tk.Frame(self, borderwidth=1, relief="solid")
        methodLabel = tk.Label(methodFrame, text="Sorting Method", font=controller.textFont)
        buttonFrame = tk.Frame(self, bg=controller.bgColor)
        alphabeticalButton = tk.Button(buttonFrame, text="Alphabetical", state="normal", command=controller.alphabetical, font=controller.buttonTextFont, activebackground=controller.buttonPressedColor)
        extensionButton = tk.Button(buttonFrame, text="Extension", state="normal", command=controller.extension, font=controller.buttonTextFont, activebackground=controller.buttonPressedColor)
        customButton = tk.Button(buttonFrame, text="Custom", state="disabled", command=controller.custom, font=controller.buttonTextFont, activebackground=controller.buttonPressedColor)
        creditsButton = tk.Button(controller, text=" * ", state="normal", command=controller.credits_toggle)

        #Layout
        titleFrame.grid(column=0, row=0)
        titleLabel.grid(column=0, row=0)
        versionLabel.grid(column=0, row=1)
        spacerFrame_1.grid(column=0, row=1)
        methodFrame.grid(column=0, row=2, pady=10)
        methodLabel.grid(column=0, row=0, pady=5, padx=3)
        buttonFrame.grid(column=0, row=3)
        alphabeticalButton.grid(column=0, row=0, padx=2)
        extensionButton.grid(column=1, row=0, padx=2)
        customButton.grid(column=2, row=0, padx=2)
        creditsButton.grid(column=0, row=0, sticky="se")
        autoRunToggle.grid(column=0, row=4, pady=15)

class CreditsPage(tk.Frame):
    def __init__(self, parent, controller):
        tk.Frame.__init__(self, parent)
        self.controller = controller

        #Widgets
        nameLabel = tk.Label(self, text="Creator/Developer/Designer", font=controller.creditsTitleFont, borderwidth=2, relief='solid', padx=5, pady=5)
        name = tk.Label(self, text="Riley Meyerkorth", font=controller.creditsFont)
        buttonsFrame = tk.Frame(self)
        githubButton = tk.Button(buttonsFrame, text="GitHub", command=lambda: webbrowser.open_new(r"https://github.com/m-riley04?tab=repositories"))
        linkedinButton = tk.Button(buttonsFrame, text="LinkedIn", command=lambda: webbrowser.open_new(r"https://www.linkedin.com/in/riley-meyerkorth-98966a1a9/"))
        #snapchatButton = tk.Button(buttonsFrame, text="Snapchat")
        #instagramButton = tk.Button(buttonsFrame, text="Instagram")

        #Container Layout
        self.grid_anchor("center")
        self.configure(borderwidth=4, relief='sunken')

        #Layout
        nameLabel.grid(column=0, row=0)
        name.grid(column=0, row=1)
        buttonsFrame.grid(column=0, row=2)
        githubButton.grid(column=0, row=0)
        linkedinButton.grid(column=1, row=0)

def main(): #Main Function
    '''Initialize Variables'''
    homeDir = os.getcwd()
    alphabetDir = homeDir + "/alphabetical"
    extDir = homeDir + "/extensions"
    customDir = homeDir + "/custom"
    alphabet = list("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
    textExtensions = ['Text Files', '.txt', '.doc', '.docx', '.rtf', '.tex', '.wpd', '.wp5']
    documentExtensions = ['Document Files', '.pdf', '.key', '.odp', '.pps', '.ppt', '.pptx', '.potx', '.potm', '.pot', '.ppam', '.ppsm', '.ppsx', ]
    audioExtensions = ['Audio Files', '.aif', '.aifc', '.aiff', '.cda', '.mid', '.midi', '.mp3', '.mpa', '.ogg', '.wav', '.wma', '.wpl', '.aac', '.adt', '.adts']
    compressedExtensions = ['Compressed Files', '.7z', '.arg', '.deb', '.pkg', '.rar', '.rpm', '.gz', '.z', '.zip']
    discExtensions = ['Disc Files', '.bin', '.dmg', '.iso', '.toast', '.vcd']
    dataExtensions = ['Data Files', '.csv', '.dat', '.db', '.dbf', '.log', '.mdb', '.sav', '.sql', '.tar', '.xml', '.ab', '.accdb', '.accde', '.accdr', '.accdt']
    emailExtensions = ['Email Files', '.email', '.eml', '.emlx', '.msg', '.oft', '.ost', '.pst', '.vcf']
    executableExtensions = ['Executable Files', '.apk', '.bat', '.bin', '.com', '.exe', '.gadget', '.jar', '.msi', '.wsf']
    fontExtensions = ['Font Files', '.fnt', '.fon', '.otf', '.ttf']
    imageExtensions = ['Image Files', '.jpg', '.jpeg', '.JPG', '.JPEG', '.gif', '.bmp', '.ico', '.png', '.ps', '.svg', '.tif', '.tiff']
    internetExtensions = ['Internet Files', '.asp', '.aspx', '.cer', '.cfm', '.css', '.htm', '.html', '.js', '.jsp', '.part', '.rss', '.xhtml']
    programmingExtensions = ['Programming Files', '.c', '.cgi', '.pl', '.class', '.cpp', '.cs', '.h', '.java', '.php', '.py', '.sh', '.swift', '.vb']
    spreadsheetExtensions = ['Spreadsheet Files', '.ods', '.xls', '.xlsm', '.xlt', '.xltm', '.xlsx']
    systemExtensions = ['System Files', '.bak', '.cab', '.cfg', '.cpl', '.cur', '.dll', '.dmp', '.drv', '.icns', '.ini', '.lnk', '.sys', '.tmp']
    videoExtensions = ['Video Files', '.3g2', '.3gp', '.avi', '.flv', '.h264', '.m4v', '.mkv', '.mov', '.mp4', '.mpg', '.mpeg', '.rm', '.swf', '.vob', '.wmv']
    adobeExtensions = ['Adobe Files', '.ai', '.psd', '.indd', '.prproj', '.aep']
    extensions = [textExtensions, documentExtensions, audioExtensions, compressedExtensions, discExtensions, dataExtensions, emailExtensions, executableExtensions, fontExtensions, imageExtensions, internetExtensions, programmingExtensions, spreadsheetExtensions, systemExtensions, videoExtensions, adobeExtensions]
         
    class RepeatedTimer(object):
        def __init__(self, interval, function, *args, **kwargs):
            self._timer     = None
            self.interval   = interval
            self.function   = function
            self.args       = args
            self.kwargs     = kwargs
            self.is_running = False
            self.start()

        def _run(self):
            self.is_running = False
            self.start()
            self.function(*self.args, **self.kwargs)

        def start(self):
            if not self.is_running:
                self._timer = Timer(self.interval, self._run)
                self._timer.start()
                self.is_running = True

        def stop(self):
            self._timer.cancel()
            self.is_running = False
    
    def is_admin():
        try:
            return ctypes.windll.shell32.IsUserAnAdmin()
        except:
            return False

    def check_for_directories(method):
        #Create Directories
        if method == "alphabet":
            if not os.path.exists(alphabetDir):
                os.mkdir(alphabetDir)
            if not os.path.exists(alphabetDir + "/.misc"):
                os.mkdir(alphabetDir + "/.misc")
            for char in alphabet:
                charPath = alphabetDir + f"/{char}"
                if not os.path.exists(charPath):
                    os.mkdir(charPath)
        elif method == "extension":
            if not os.path.exists(extDir):
                os.mkdir(extDir)
            if not os.path.exists(extDir + "/.Misc Extensions"):
                os.mkdir(extDir + "/.Misc Extensions")
            if not os.path.exists(extDir + "/.Folders"):
                os.mkdir(extDir + "/.Folders")
            for ext in extensions:
                extPath = extDir + f"/{ext[0]}"
                if not os.path.exists(extPath):
                    os.mkdir(extPath)
        elif method == "custom":
            if not os.path.exists(customDir):
                os.mkdir(customDir)

    def update(): #Update Function - 1 per sec
        folderContents = os.listdir(homeDir)
        for obj in folderContents:
            if os.path.basename(obj) != f"{appName}.exe" and os.path.basename(obj) != f"{appName}.py" and os.path.basename(obj) != "alphabetical" and os.path.basename(obj) != "extensions" and os.path.basename(obj) != "custom":
                sort(obj, sortingMethod)
        logging.info(msg=f"Folder Refreshed")

    def sort(obj, method):
        if method == "alphabet":
            sort_alphabetical(obj)
        elif method == "extension":
            sort_extension(obj)
        elif method == "custom":
            sort_custom(obj)
        else:
            pass
        logging.info(msg=f"{obj} sorted using {method} sorting method.")

    def sort_alphabetical(file):
        firstLetter = file[0].lower()
        fileTup = os.path.splitext(file)
        fileName = fileTup[0]
        fileExt = fileTup[1]
        fileCurrentPath = homeDir + f"/{file}"
        try:
            fileDestinationPath = alphabetDir + f"/{firstLetter}/{fileName}"    #--File destination without extension
            while os.path.exists(fileDestinationPath + fileExt):            #--Check for duplicate name
                fileDestinationPath += " copy"                              #--Add "copy" to dupe
            fileDestinationPath += fileExt                                  #--Re-add file extension
        except:
            fileDestinationPath = alphabetDir + f"/.misc/{fileName}" 
            while os.path.exists(fileDestinationPath + fileExt):
                fileDestinationPath += " copy"
            fileDestinationPath += fileExt
        shutil.move(src=fileCurrentPath, dst=fileDestinationPath)
    
    def sort_extension(file):
        fileTup = os.path.splitext(file)
        fileName = fileTup[0]
        fileExt = fileTup[1]
        fileCurrentPath = homeDir + f"/{fileName}{fileExt}"
        fileDestinationPath = extDir + f"/.Misc Extensions/{fileName}{fileExt}"
        try:
            for extensionList in extensions:
                if fileExt in extensionList:
                    fileDestinationPath = extDir + f"/{extensionList[0]}/{fileName}"    #File destination without extension
                    while os.path.exists(fileDestinationPath + fileExt):                #Check for duplicate name
                        fileDestinationPath += " copy"                                  #Add "copy" to dupe
                    fileDestinationPath += fileExt                                      #Re-add file extension
        except:
            fileDestinationPath = extDir + f"/.Misc Extensions/{fileName}"
            while os.path.exists(fileDestinationPath + fileExt):
                fileDestinationPath += " copy"
            fileDestinationPath += fileExt
        shutil.move(src=fileCurrentPath, dst=fileDestinationPath)
        
    def sort_custom(file):
        pass

    def hide_terminal():
        '''Hides the terminal'''
        kernel32 = ctypes.WinDLL('kernel32')
        user32 = ctypes.WinDLL('user32')

        SW_HIDE = 0

        hWnd = kernel32.GetConsoleWindow()
        if hWnd:
            user32.ShowWindow(hWnd, SW_HIDE)

    hide_terminal()
    app = App()
    app.mainloop()
    sortingMethod = app.sortingMethod
    print(sortingMethod)
    appName = app.appName
    logging.info(msg=f"Sorting Method Chosen: {sortingMethod}")

    #if is_admin(): #--Check for admin privliges
    check_for_directories(sortingMethod)
    if app.sortingMethod != "":
        rt = RepeatedTimer(interval=1, function=update)
    #else: #--Get admin Privilages
    #    ctypes.windll.shell32.ShellExecuteW(None, "runas", sys.executable, " ".join(sys.argv), None, 1)

#====================================================#

if __name__ == "__main__":
    main()