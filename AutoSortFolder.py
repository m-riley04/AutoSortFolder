#AutoSortFolder.py
'''

AutoSortFolder
v1.0.0

github: https://github.com/m-riley04/AutoSortFolder
written: riley meyerkorth

'''
import os, time, shutil, ctypes, logging, webbrowser, winreg, base64, pystray, colorsys, PIL.Image; import numpy as np; from threading import Timer; import tkinter as tk; from tkinter import colorchooser

#----------------------------------------------------------------------------------GUI Classes/Objects
#---------------------------------------------App() Window/Controller
class App(tk.Tk):
    '''Tkinter Main Application Window'''
    '''
        
        Explanation:
        This class is a child of the Tkinter "Tk()" object, which
        is essentially the window of the application. It also 
        controls the "stacking" of each page of the application.
        Essentially, it works the same way as a deck of cards. The
        pages are stacked one on top of each other. When one needs
        to be shown, it is placed at the top of the deck above
        the others. It makes organizing the GUI a lot less
        stressful and much more compact.

    '''
    #-------------------------------------------------------------------------App() Variables
    def __init__(self, *args, **kwargs):                        # Inherits arguments from base class "Tk()"
        '''Initialize App Class'''
        tk.Tk.__init__(self, *args, **kwargs)                   

        #-----------------------------------Vars
        self.appName = "AutoSortFolder"                         # The main app name
        self.version = "v1.0.0"
        self.trayIconHue = 0                                    # The tray icon hue
        self.trayIconCurrentColor = (255, 0, 0)
        self.sortingMethod = ""                                 # The selected sorting method
        self.sortingActive = True
        self.keywordsToSort = []                                # The keywords to sort (for the custom method)
        self.currentPage = "MainPage"                           # The current page shown in the window
        self.rgb_to_hsv = np.vectorize(colorsys.rgb_to_hsv)
        self.hsv_to_rgb = np.vectorize(colorsys.hsv_to_rgb)

        self.attributes("-topmost", True)

        #-----------------------------------Colors
        self.bgColor = "#242424"                                # The overall background color for frames and the window
        self.bgLightColor = "#575656"                             # The overall background color for inner frames
        #self.titleColor = "black"                              # The overall title color
        self.textColorDark = "#e8e8e8"                            # The overall dark text color
        self.textColorLight = "white"                           # The overall light text color
        self.buttonColor = "white"                              # The overall button color
        self.buttonTextColor = "black"                          # The overall button text color
        self.buttonPressedColor = "red"                        # The overall button pressed color

        #-----------------------------------Fonts
        self.appNameFont = ("Cascadia Code Semibold", 35)       # The app title font
        self.titleFont = ("Cascadia Code Semibold", 25)         # The overall base title font
        self.textFont = ("Cascadia Code Light", 12)             # The overall base font
        self.buttonTextFont = ("Cascadia Code Light", 8)        # The overall base button text font
        self.creditsTitleFont = ("Cascadia Code Semibold", 15)  # The font for the title in CreditsPage
        self.creditsFont = ("Cascadia Code Regular", 13)        # The base font in CreditsPage

        #-----------------------------------Window Configuration
        self.configure(bg=self.bgColor)                         # Sets the background color of the window to the universal bg color
        self.resizable(False, False)                            # Sets whether the window is resizable based on a tuple - (width, height)
        self.grid_anchor("center")                              # Anchors everything in the base app window to the center at all times
        self.geometry("600x425")                                # Sets the window size
        self.title("AutoSorterFolder")                          # Sets the title of the window

        #-----------------------------------Stack Container Frame
        container = tk.Frame(self)                              # Creation of page container frame - each page is within this frame
        container.configure(bg=self.bgColor)                    # Sets the background color of the container frame to the universal bg color
        container.grid_anchor("center")                         # Anchors the container in the center of the window at all times
        container.grid_rowconfigure(0, weight=1)                # 
        container.grid_columnconfigure(0, weight=1)             # 
        container.grid(column=0, row=0)                         # Places the container on the grid of the window (this needs to happen or it won't appear)

        self.frames = {}                                        # Dictionary of the app frames
        for F in (MainPage, CreditsPage, CustomSortingPage, SettingsPage, ColorOptionsPage, ApplicationOptionsPage):    # For every "card" (page) in the "deck" (app) 
            page_name = F.__name__                              # Get page __name__
            frame = F(parent=container, controller=self)        # Creates a frame for the page (the controller)
            self.frames[page_name] = frame                      # Adds the frame to a dictionary with the page name as the key
            frame.grid(row=0, column=0, sticky="nsew")          # Aligns the controller/page frame to be center (sticky in all directions)

        self.show_frame("MainPage")                             # Brings the MainPage to the top of the deck

    #-------------------------------------------------------------------------App() Functions
    def show_frame(self, page_name):
        '''Show a frame for the given page name'''
        frame = self.frames[page_name]              # Gets the value in frames dictionary for page_name...
        frame.tkraise()                             # ...and raises it to the top of the deck
    
    def destroy_window(self):
        '''Destroy app window'''
        self.destroy()              # ...destroys the app window...self explanatory

    def alphabetical(self):
        '''Set sorting method to "alphabet" and destroys the window'''
        self.sortingMethod = "alphabet"                                 # Sets the sorting method
        self.destroy_window()                                           # Then destroys the window

    def extension(self):
        '''Set sorting method to "extension" and destroys the window'''
        self.sortingMethod = "extension"                                # Sets the sorting method
        self.destroy_window()                                           # Then destroys the window

    def custom(self):
        '''Set sorting method to "custom" and destroys the window'''
        self.sortingMethod = "custom"                                   # Sets the sorting method
        self.destroy_window()                                           # Then destroys the window

    def credits_toggle(self):
        '''Toggles between the credits page'''
        if self.currentPage == "MainPage":      # If the current page is the home page...
            self.show_frame("CreditsPage")      # Bring the credits page to the top
            self.currentPage = "CreditsPage"    # AND set currentPage to CreditsPage.
        else:                                   # Otherwise if the current page ISNT the home page...
            self.show_frame("MainPage")         # Bring the home page to the top
            self.currentPage = "MainPage"       # AND set currentPage to MainPage.

    def add_to_registry(self): # NOTE: THIS IS SET FOR EXE's RIGHT NOW, NOT .py
        '''Add the app path to the registry to auto-start'''
        directoryPath = os.path.dirname(os.path.realpath(__file__))     # Gets the directory path of the file
        fileName = self.appName + ".exe"                                # Gets the file name from appName and extension (add toggle later?)
        filePath = f'"{directoryPath}\{fileName}"'                      # Combines directory path and file name

        #Registry
        key = winreg.HKEY_CURRENT_USER                                          # Sets registry key
        key_value = "Software\Microsoft\Windows\CurrentVersion\Run"             # Sets registry key path
        openKey = winreg.OpenKey(key, key_value, 0, winreg.KEY_ALL_ACCESS)      # Opens the key using winreg
        winreg.SetValueEx(openKey, self.appName, 0, winreg.REG_SZ, filePath)    # Sets the value of the key
        winreg.CloseKey(openKey)                                                # Closes the key

    def shift_hue(self, rgb, hout):
        r, g, b = np.array(rgb)
        h, s, v = self.rgb_to_hsv(r, g, b)
        h = hout
        r, g, b = np.array(self.hsv_to_rgb(h, s, v)).astype(int)
        rgb = (r, g, b)
        return rgb

    def shift_image_hue(self, arr, hout):
        r, g, b, a = np.rollaxis(arr, axis=-1)
        h, s, v = self.rgb_to_hsv(r, g, b)
        h = hout
        r, g, b = self.hsv_to_rgb(h, s, v)
        arr = np.dstack((r, g, b, a))
        return arr

    def colorize(self, image, hue):
        """
        Colorize PIL image `original` with the given
        `hue` (hue within 0-360); returns another PIL image.
        """
        img = image.convert('RGBA')
        arr = np.array(np.asarray(img).astype('float'))
        new_img = PIL.Image.fromarray(self.shift_image_hue(arr, hue/360.).astype('uint8'), 'RGBA')

        return new_img

#---------------------------------------------App() Pages
class MainPage(tk.Frame):
    '''Tkinter Main Page'''
    '''
        
        Explanation:
        This class is a child of the Tkinter "Frame()" object. "Frame()"
        children are what all pages are based from. The first three lines
        (not including comments) are the required copy-paste lines that
        set up the page to connect to the App(). After that, it's up to
        you what you design.
        This page acts as the home page of the application.

    '''
    #-------------------------------------------------------------------------MainPage() Variables
    def __init__(self, parent, controller):                                     
        '''Initialize Main Page'''
        tk.Frame.__init__(self, parent)
        self.controller = controller

        #-------------------------------------------------------------------------MainPage()Functions
        def go_to_settings():
            '''Goes to the settings page'''
            controller.show_frame("SettingsPage")
            controller.currentPage = "SettingsPage"
        
        #-------------------------------------------------------------------------MainPage() Color BG
        self.configure(bg=controller.bgColor)

        #-------------------------------------------------------------------------MainPage() Widgets
        titleFrame = tk.Frame(self, borderwidth=4, relief="solid")
        titleLabel = tk.Label(titleFrame, text=controller.appName, font=controller.appNameFont)
        versionLabel = tk.Label(titleFrame, text=controller.version)
        self.spacerFrame_1 = tk.Frame(self, height=40, bg=controller.bgColor)
        self.embeddedFrame = tk.Frame(self, bg=controller.bgLightColor, borderwidth=4, relief='sunken', padx=10, pady=10)
        methodFrame = tk.Frame(self.embeddedFrame, borderwidth=1, relief="solid")
        methodLabel = tk.Label(methodFrame, text="Sorting Method", font=controller.textFont)
        self.buttonFrame = tk.Frame(self.embeddedFrame, bg=controller.bgLightColor)
        self.alphabeticalButton = tk.Button(self.buttonFrame, text="Alphabetical", state="normal", command=controller.alphabetical, font=controller.buttonTextFont, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.extensionButton = tk.Button(self.buttonFrame, text="Extension", state="normal", command=controller.extension, font=controller.buttonTextFont, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.customButton = tk.Button(self.buttonFrame, text="Custom", state="normal", command=controller.custom, font=controller.buttonTextFont, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.spacerFrame_2 = tk.Frame(controller, height=50, bg=controller.bgColor)
        self.topButtons = tk.Frame(controller, bg=controller.bgColor)
        self.settingsButton = tk.Button(self.topButtons, text="Settings", command=go_to_settings, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.creditsButton = tk.Button(self.topButtons, text="Credits/Home", state="normal", command=controller.credits_toggle, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)

        #-------------------------------------------------------------------------MainPage() Layout
        titleFrame.grid(column=0, row=0)
        titleLabel.grid(column=0, row=0)
        versionLabel.grid(column=0, row=1)
        self.spacerFrame_1.grid(column=0, row=1)
        self.embeddedFrame.grid(column=0, row=2)
        methodFrame.grid(column=0, row=0, pady=10)
        methodLabel.grid(column=0, row=0, pady=5, padx=3)
        self.buttonFrame.grid(column=0, row=1)
        self.alphabeticalButton.grid(column=0, row=0, padx=2)
        self.extensionButton.grid(column=1, row=0, padx=2)
        self.customButton.grid(column=2, row=0, padx=2)
        self.spacerFrame_2.grid(column=0, row=1)
        self.topButtons.grid(column=0, row=1, pady=15)
        self.creditsButton.grid(column=0, row=0, padx=2)
        self.settingsButton.grid(column=1, row=0, padx=2)


class CreditsPage(tk.Frame):
    '''Tkinter Credits Page'''
    def __init__(self, parent, controller):
        '''Initialize Credits Page'''
        tk.Frame.__init__(self, parent)
        self.controller = controller

        #Widgets
        nameLabel = tk.Label(self, text="Creator/Developer/Designer", font=controller.creditsTitleFont, borderwidth=2, relief='solid', padx=5, pady=5)
        self.name = tk.Label(self, text="Riley Meyerkorth", font=controller.creditsFont)
        self.buttonsFrame = tk.Frame(self, bg=controller.bgLightColor)
        self.githubButton = tk.Button(self.buttonsFrame, text="GitHub", command=lambda: webbrowser.open_new(r"https://github.com/m-riley04?tab=repositories"), bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.linkedinButton = tk.Button(self.buttonsFrame, text="LinkedIn", command=lambda: webbrowser.open_new(r"https://www.linkedin.com/in/riley-meyerkorth-98966a1a9/"), bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        #snapchatButton = tk.Button(buttonsFrame, text="Snapchat", bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        #instagramButton = tk.Button(buttonsFrame, text="Instagram", bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)

        #Container Layout
        self.grid_anchor("center")
        self.configure(borderwidth=4, relief='sunken', bg=controller.bgLightColor)

        #Layout
        nameLabel.grid(column=0, row=0)
        self.name.grid(column=0, row=1, pady=10)
        self.buttonsFrame.grid(column=0, row=2)
        self.githubButton.grid(column=0, row=0, padx=2)
        self.linkedinButton.grid(column=1, row=0, padx=2)


class SettingsPage(tk.Frame):
    '''Settings Page'''
    def __init__(self, parent, controller):
        '''Initialize Credits Page'''
        tk.Frame.__init__(self, parent)
        self.controller = controller

        #-------------------------------------------------------------------------SettingsPage() Container Properties
        self.grid_anchor("center")
        self.configure(borderwidth=4, relief='sunken')

        #-------------------------------------------------------------------------SettingsPage() Methods
        def goto_color_options():
            controller.show_frame("ColorOptionsPage")
            controller.currentPage = "ColorOptionsPage"

        def goto_custom_sorting_options():
            controller.show_frame("CustomSortingPage")
            controller.currentPage = "CustomSortingPage"

        def goto_application_options():
            controller.show_frame("ApplicationOptionsPage")
            controller.currentPage = "ApplicationOptionsPage"

        #-------------------------------------------------------------------------SettingsPage() Widgets
        #---------Base Frame Widgets
        self.configure(bg=controller.bgLightColor)
        title = tk.Label(self, text="Settings", font=controller.titleFont, borderwidth=2, relief="solid", padx=10, pady=2)
        self.explanation = tk.Label(self, text="Customize the sorting (and the app) to your liking!", wraplength=200, bg=controller.bgLightColor, fg=controller.textColorDark)
        self.settingsMenu_spacer = tk.Frame(self, height=10, bg=controller.bgLightColor)

        #---------Settings Menu Buttons
        self.settingsMenu_frame = tk.Frame(self, bg=controller.bgLightColor)
        self.settingsMenu_colors_button = tk.Button(self.settingsMenu_frame, text="Color Options", command=goto_color_options, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.settingsMenu_customSorting_button = tk.Button(self.settingsMenu_frame, text="Custom Sorting Options", command=goto_custom_sorting_options, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.settingsMenu_app_button = tk.Button(self.settingsMenu_frame, text="Application Options", command=goto_application_options, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)

        
        #-------------------------------------------------------------------------SettingsPage() Layout
        #--Container Frame
        title.grid(column=0, row=0)
        self.explanation.grid(column=0, row=1)
        self.settingsMenu_spacer.grid(column=0, row=2)
        self.settingsMenu_frame.grid(column=0, row=3)

        #--Settings Menu Buttons
        self.settingsMenu_colors_button.grid(column=0, row=0, pady=5)
        self.settingsMenu_customSorting_button.grid(column=0, row=1, pady=5)
        self.settingsMenu_app_button.grid(column=0, row=3, pady=5)


class ColorOptionsPage(tk.Frame):
    '''Color Options Page'''
    def __init__(self, parent, controller):
        '''Initialize Credits Page'''
        tk.Frame.__init__(self, parent)
        self.controller = controller

        #-------------------------------------------------------------------------ColorOptionsPage() Container Properties
        self.grid_anchor("center")
        self.configure(borderwidth=4, relief='sunken')
        buttonPaddingx = 2
        buttonPaddingy = 2

        #-------------------------------------------------------------------------ColorOptionsPage() Methods
        def choose_bg_color():
            '''Opens color window to select background color'''
            colorCode = colorchooser.askcolor(title="Set Background Color")
            controller.bgColor = colorCode[1]

            controller.configure(bg=controller.bgColor)                         #Apply color changes to all frames
            #--------------------Main Page Configs
            controller.frames["MainPage"].configure(bg=controller.bgColor)
            controller.frames["MainPage"].spacerFrame_1.configure(bg=controller.bgColor)
            controller.frames["MainPage"].topButtons.configure(bg=controller.bgColor)
            controller.frames["MainPage"].spacerFrame_2.configure(bg=controller.bgColor)
        
        def choose_bgLight_color():
            '''Opens color window to select light background color'''
            colorCode = colorchooser.askcolor(title="Set Light Background Color")
            controller.bgLightColor = colorCode[1]

            #--------------------Main Page Configs
            controller.frames["MainPage"].embeddedFrame.configure(bg=controller.bgLightColor)
            controller.frames["MainPage"].buttonFrame.configure(bg=controller.bgLightColor)
            #--------------------Credits Page Configs
            controller.frames["CreditsPage"].configure(bg=controller.bgLightColor)
            #--------------------Settings Page Configs
            controller.frames["SettingsPage"].configure(bg=controller.bgLightColor)
            controller.frames["SettingsPage"].explanation.configure(bg=controller.bgLightColor)
            controller.frames["SettingsPage"].settingsMenu_spacer.configure(bg=controller.bgLightColor)
            controller.frames["SettingsPage"].settingsMenu_frame.configure(bg=controller.bgLightColor)
            #--------------------Custom Sorting Page Configs
            controller.frames["CustomSortingPage"].configure(bg=controller.bgLightColor)
            controller.frames["CustomSortingPage"].explanation.configure(bg=controller.bgLightColor)
            controller.frames["CustomSortingPage"].keywordsLabel_frame.configure(bg=controller.bgLightColor)
            controller.frames["CustomSortingPage"].keywordEntry_frame.configure(bg=controller.bgLightColor)
            #--------------------Color Options Page Configs
            controller.frames["ColorOptionsPage"].configure(bg=controller.bgLightColor)
            controller.frames["ColorOptionsPage"].explanation.configure(bg=controller.bgLightColor)
            controller.frames["ColorOptionsPage"].colorOptions_spacer.configure(bg=controller.bgLightColor)
            controller.frames["ColorOptionsPage"].colorOptions_frame.configure(bg=controller.bgLightColor)
            #--------------------Application Options Page Configs
            controller.frames["ApplicationOptionsPage"].configure(bg=controller.bgLightColor)
            controller.frames["ApplicationOptionsPage"].explanation.configure(bg=controller.bgLightColor)
            #controller.frames["ApplicationOptionsPage"].applicationOptions_spacer.configure(bg=controller.bgLightColor)
            #controller.frames["ApplicationOptionsPage"].applicationOptions_autorun_check.configure(bg=controller.bgLightColor)
            controller.frames["ApplicationOptionsPage"].applicationOptions_autorun_check.configure(selectcolor=controller.textColorDark)
            controller.frames["ApplicationOptionsPage"].applicationOptions_trayiconhue_scale.configure(bg=controller.bgLightColor)
            controller.frames["ApplicationOptionsPage"].applicationOptions_frame.configure(bg=controller.bgLightColor)

        def choose_bgButton_color():
            '''Opens color window to select button background color'''
            colorCode = colorchooser.askcolor(title="Set Button Background Color")
            controller.buttonColor = colorCode[1]

            #--------------------Main Page Configs
            controller.frames["MainPage"].alphabeticalButton.configure(bg=controller.buttonColor)
            controller.frames["MainPage"].extensionButton.configure(bg=controller.buttonColor)
            controller.frames["MainPage"].customButton.configure(bg=controller.buttonColor)
            controller.frames["MainPage"].settingsButton.configure(bg=controller.buttonColor)
            controller.frames["MainPage"].creditsButton.configure(bg=controller.buttonColor)
            #--------------------Credits Page Configs
            controller.frames["CreditsPage"].githubButton.configure(bg=controller.buttonColor)
            controller.frames["CreditsPage"].linkedinButton.configure(bg=controller.buttonColor)
            #--------------------Settings Page Configs
            controller.frames["SettingsPage"].settingsMenu_colors_button.configure(bg=controller.buttonColor)
            controller.frames["SettingsPage"].settingsMenu_customSorting_button.configure(bg=controller.buttonColor)
            controller.frames["SettingsPage"].settingsMenu_app_button.configure(bg=controller.buttonColor)
            #--------------------Custom Sorting Page Configs
            controller.frames["CustomSortingPage"].keywordEntry_button.configure(bg=controller.buttonColor)
            controller.frames["CustomSortingPage"].keywordsLabel_button.configure(bg=controller.buttonColor)
            #--------------------Color Options Page Configs
            controller.frames["ColorOptionsPage"].colorOptions_bg_button.configure(bg=controller.buttonColor)
            controller.frames["ColorOptionsPage"].colorOptions_bgLight_button.configure(bg=controller.buttonColor)
            controller.frames["ColorOptionsPage"].colorOptions_bgButton_button.configure(bg=controller.buttonColor)
            controller.frames["ColorOptionsPage"].colorOptions_textLight_button.configure(bg=controller.buttonColor)
            controller.frames["ColorOptionsPage"].colorOptions_darkText_button.configure(bg=controller.buttonColor)
            controller.frames["ColorOptionsPage"].colorOptions_textButtons_button.configure(bg=controller.buttonColor)
            controller.frames["ColorOptionsPage"].colorOptions_buttonPressed_button.configure(bg=controller.buttonColor)

        def choose_textLight_color():
            '''Opens color window to select light text color'''
            colorCode = colorchooser.askcolor(title="Set Text Light Color")
            controller.textColorLight = colorCode[1]

            #--------------------Main Page Configs
            #controller.frames["MainPage"].buttonFrame.configure(fg=controller.textColorLight)
            #--------------------Credits Page Configs
            
            #--------------------Settings Page Configs

            #--------------------Custom Sorting Page Configs

            #--------------------Color Options Page Configs
            pass

        def choose_textDark_color():
            '''Opens color window to select dark text color'''
            colorCode = colorchooser.askcolor(title="Set Dark Text Color")
            controller.textColorDark = colorCode[1]

            #--------------------Main Page Configs
            #controller.frames["MainPage"].buttonFrame.configure(fg=controller.textColorDark)
            #--------------------Credits Page Configs
            #controller.frames["CreditsPage"].name.configure(fg=controller.textColorDark)
            #--------------------Settings Page Configs
            controller.frames["SettingsPage"].explanation.configure(fg=controller.textColorDark)
            #--------------------Custom Sorting Page Configs
            controller.frames["CustomSortingPage"].explanation.configure(fg=controller.textColorDark)
            #--------------------Color Options Page Configs
            controller.frames["ColorOptionsPage"].explanation.configure(fg=controller.textColorDark)
            #--------------------Application Options Page Configs
            #controller.frames["ApplicationOptionsPage"].explanation.configure(fg=controller.textColorDark)

        def choose_textButtons_color():
            '''Opens color window to select button text color'''
            colorCode = colorchooser.askcolor(title="Set Button Text Color")
            controller.buttonTextColor = colorCode[1]

            #--------------------Main Page Configs
            controller.frames["MainPage"].alphabeticalButton.configure(fg=controller.buttonTextColor)
            controller.frames["MainPage"].extensionButton.configure(fg=controller.buttonTextColor)
            controller.frames["MainPage"].customButton.configure(fg=controller.buttonTextColor)
            controller.frames["MainPage"].settingsButton.configure(fg=controller.buttonTextColor)
            controller.frames["MainPage"].creditsButton.configure(fg=controller.buttonTextColor)
            #--------------------Credits Page Configs
            controller.frames["CreditsPage"].githubButton.configure(fg=controller.buttonTextColor)
            controller.frames["CreditsPage"].linkedinButton.configure(fg=controller.buttonTextColor)
            #--------------------Settings Page Configs
            controller.frames["SettingsPage"].settingsMenu_colors_button.configure(fg=controller.buttonTextColor)
            controller.frames["SettingsPage"].settingsMenu_customSorting_button.configure(fg=controller.buttonTextColor)
            controller.frames["SettingsPage"].settingsMenu_app_button.configure(fg=controller.buttonTextColor)
            #--------------------Custom Sorting Page Configs
            controller.frames["CustomSortingPage"].keywordEntry_button.configure(fg=controller.buttonTextColor)
            controller.frames["CustomSortingPage"].keywordsLabel_button.configure(fg=controller.buttonTextColor)
            #--------------------Color Options Page Configs
            controller.frames["ColorOptionsPage"].colorOptions_bg_button.configure(fg=controller.buttonTextColor)
            controller.frames["ColorOptionsPage"].colorOptions_bgLight_button.configure(fg=controller.buttonTextColor)
            controller.frames["ColorOptionsPage"].colorOptions_bgButton_button.configure(fg=controller.buttonTextColor)
            controller.frames["ColorOptionsPage"].colorOptions_textLight_button.configure(fg=controller.buttonTextColor)
            controller.frames["ColorOptionsPage"].colorOptions_darkText_button.configure(fg=controller.buttonTextColor)
            controller.frames["ColorOptionsPage"].colorOptions_textButtons_button.configure(fg=controller.buttonTextColor)
            controller.frames["ColorOptionsPage"].colorOptions_buttonPressed_button.configure(fg=controller.buttonTextColor)
        
        def choose_buttonPressed_color():
            '''Opens color window to select button text color'''
            '''TEMPLATE'''
            colorCode = colorchooser.askcolor(title="Set Button Press Color")
            controller.buttonPressedColor = colorCode[1]

            #--------------------Main Page Configs
            controller.frames["MainPage"].alphabeticalButton.configure(activebackground=controller.buttonPressedColor)
            controller.frames["MainPage"].extensionButton.configure(activebackground=controller.buttonPressedColor)
            controller.frames["MainPage"].customButton.configure(activebackground=controller.buttonPressedColor)
            controller.frames["MainPage"].settingsButton.configure(activebackground=controller.buttonPressedColor)
            controller.frames["MainPage"].creditsButton.configure(activebackground=controller.buttonPressedColor)
            #--------------------Credits Page Configs
            controller.frames["CreditsPage"].githubButton.configure(activebackground=controller.buttonPressedColor)
            controller.frames["CreditsPage"].linkedinButton.configure(activebackground=controller.buttonPressedColor)
            #--------------------Settings Page Configs
            controller.frames["SettingsPage"].settingsMenu_colors_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["SettingsPage"].settingsMenu_customSorting_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["SettingsPage"].settingsMenu_app_button.configure(activebackground=controller.buttonPressedColor)
            #--------------------Custom Sorting Page Configs
            controller.frames["CustomSortingPage"].keywordEntry_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["CustomSortingPage"].keywordsLabel_button.configure(activebackground=controller.buttonPressedColor)
            #--------------------Color Options Page Configs
            controller.frames["ColorOptionsPage"].colorOptions_bg_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["ColorOptionsPage"].colorOptions_bgLight_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["ColorOptionsPage"].colorOptions_bgButton_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["ColorOptionsPage"].colorOptions_textLight_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["ColorOptionsPage"].colorOptions_darkText_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["ColorOptionsPage"].colorOptions_textButtons_button.configure(activebackground=controller.buttonPressedColor)
            controller.frames["ColorOptionsPage"].colorOptions_buttonPressed_button.configure(activebackground=controller.buttonPressedColor)

        def choose_template_color():
            '''Opens color window to select button text color'''
            '''TEMPLATE'''
            colorCode = colorchooser.askcolor(title="Set ________ Color")
            controller.bgColor = colorCode[1]

            #--------------------Main Page Configs

            #--------------------Credits Page Configs

            #--------------------Settings Page Configs

            #--------------------Custom Sorting Page Configs

            #--------------------Color Options Page Configs
            pass

        #-------------------------------------------------------------------------ColorOptionsPage() Widgets
        #---------Base Frame Widgets
        title = tk.Label(self, text="Color Options", font=controller.titleFont, border=2, relief="solid", padx=10)
        self.explanation = tk.Label(self, text="Customize the colors of the GUI to your liking", wraplength=200, fg=controller.textColorDark, bg=controller.bgLightColor)
        self.colorOptions_spacer = tk.Frame(self, height=10, bg=controller.bgLightColor)

        #---------Settings Menu Buttons
        self.colorOptions_frame = tk.Frame(self, bg=controller.bgLightColor)
        self.colorOptions_bg_button = tk.Button(self.colorOptions_frame, text="Background", command=choose_bg_color, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.colorOptions_bgLight_button = tk.Button(self.colorOptions_frame, text="Light BG", command=choose_bgLight_color, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.colorOptions_bgButton_button = tk.Button(self.colorOptions_frame, text="Buttons BG", command=choose_bgButton_color, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.colorOptions_textLight_button = tk.Button(self.colorOptions_frame, text="Light Text", state="disabled", command=choose_textLight_color, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.colorOptions_darkText_button = tk.Button(self.colorOptions_frame, text="Dark Text", command=choose_textDark_color, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.colorOptions_textButtons_button = tk.Button(self.colorOptions_frame, text="Button Text", command=choose_textButtons_color, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.colorOptions_buttonPressed_button = tk.Button(self.colorOptions_frame, text="Button Press", command=choose_buttonPressed_color, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)

        #-------------------------------------------------------------------------ColorOptionsPage() Layout
        #--Container Frame
        self.configure(bg=controller.bgLightColor)
        title.grid(column=0, row=0)
        self.explanation.grid(column=0, row=1)
        self.colorOptions_spacer.grid(column=0, row=2)
        self.colorOptions_frame.grid(column=0, row=3)

        #--Settings Menu Buttons
        self.colorOptions_bg_button.grid(column=0, row=0, pady=buttonPaddingy, padx=buttonPaddingx, sticky="nesw")
        self.colorOptions_bgLight_button.grid(column=1, row=0, pady=buttonPaddingy, padx=buttonPaddingx, sticky="nesw")
        self.colorOptions_bgButton_button.grid(column=2, row=0, pady=buttonPaddingy, padx=buttonPaddingx, sticky="nesw")
        self.colorOptions_textLight_button.grid(column=0, row=1, pady=buttonPaddingy, padx=buttonPaddingx, sticky="nesw")
        self.colorOptions_darkText_button.grid(column=1, row=1, pady=buttonPaddingy, padx=buttonPaddingx, sticky="nesw")
        self.colorOptions_textButtons_button.grid(column=2, row=1, pady=buttonPaddingy, padx=buttonPaddingx, sticky="nesw")
        self.colorOptions_buttonPressed_button.grid(column=0, row=2, columnspan=3, pady=buttonPaddingy, padx=buttonPaddingx, sticky="nesw")


class CustomSortingPage(tk.Frame):
    '''Custom Sorting Page'''
    def __init__(self, parent, controller):
        '''Initialize Credits Page'''
        tk.Frame.__init__(self, parent)
        self.controller = controller

        #Container Layout
        self.grid_anchor("center")
        self.configure(borderwidth=4, relief='sunken', bg=controller.bgLightColor)

        #Methods
        def add_keyword():
            added = keywordEntry_entry.get()
            if added != "":
                controller.keywordsToSort.append(added)
                keywordsLabel_label_keywords['text'] = str(controller.keywordsToSort)
                keywordEntry_entry.delete(0, tk.END)

        def reset_keywords():
            controller.keywordsToSort.clear()
            keywordsLabel_label_keywords['text'] = "[]"

        #Widgets
        title = tk.Label(self, text="Custom Options", font=controller.titleFont, borderwidth=2, relief="solid", padx=10)
        self.explanation = tk.Label(self, text="Insert one-by-one keywords you would like to create folders to sort files into (by priority)", wraplength=250, bg=controller.bgLightColor, fg=controller.textColorDark)
        self.keywordEntry_frame = tk.Frame(self, bg=controller.bgLightColor, pady=10)
        keywordEntry_entry = tk.Entry(self.keywordEntry_frame)
        self.keywordEntry_button = tk.Button(self.keywordEntry_frame, text="Add", command=add_keyword, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        self.keywordsLabel_frame = tk.Frame(self, bg=controller.bgLightColor)
        keywordsLabel_label_title = tk.Label(self.keywordsLabel_frame, text="Keywords: ", border=1, relief="solid", padx=3, pady=3)
        keywordsLabel_label_keywords = tk.Label(self.keywordsLabel_frame, text="[]", wraplength=400, border=1, relief="solid", padx=3, pady=3)
        self.keywordsLabel_button = tk.Button(self.keywordsLabel_frame, text="Reset", command=reset_keywords, bg=controller.buttonColor, fg=controller.buttonTextColor, activebackground=controller.buttonPressedColor)
        #doneButton = tk.Button(self, text="Done and Start", command=controller.custom)
        
        #Layout
        #--Container
        title.grid(column=0, row=0)
        self.explanation.grid(column=0, row=1)
        self.keywordEntry_frame.grid(column=0, row=2)
        self.keywordsLabel_frame.grid(column=0, row=3)
        #doneButton.grid(column=0, row=4, pady=10)

        #--Keyword Entry Frame
        keywordEntry_entry.grid(column=0, row=0, padx=5)
        self.keywordEntry_button.grid(column=1, row=0, padx=5)

        #--Keywords Frame
        keywordsLabel_label_title.grid(column=0, row=0, padx=1)
        keywordsLabel_label_keywords.grid(column=1, row=0, padx=3)
        self.keywordsLabel_button.grid(column=2, row=0, padx=6)


class ApplicationOptionsPage(tk.Frame):
    '''Application Options Page'''
    def __init__(self, parent, controller):
        '''Initialize Credits Page'''
        tk.Frame.__init__(self, parent)
        self.controller = controller

        #-------------------------------------------------------------------------ApplicationOptionsPage() Container Properties
        self.grid_anchor("center")
        self.configure(borderwidth=4, relief='sunken')

        #-------------------------------------------------------------------------ApplicationOptionsPage() Methods
        def auto_run_toggle():
            '''Command for auto-run (calls add_to_registry())'''
            if autoRunVar.get() == True:
                print("Added to registry")
                controller.add_to_registry()

        def rgb_to_hex(rgb):
            return '#%02x%02x%02x' % rgb

        def change_hue(self):
            controller.trayIconHue = trayHue.get()
            controller.trayIconCurrentColor = controller.shift_hue(controller.trayIconCurrentColor, controller.trayIconHue/360.)
            trayColorInHex = rgb_to_hex(controller.trayIconCurrentColor)
            applicationOptions_huevisual_canvas.configure(bg=trayColorInHex)

        #-------------------------------------------------------------------------ApplicationOptionsPage() Vars
        autoRunVar = tk.BooleanVar()
        autoRunVar.set(False)
        trayHue = tk.IntVar()
        trayHue.set(0)
        trayColorInHex = rgb_to_hex(controller.trayIconCurrentColor)

        #-------------------------------------------------------------------------ApplicationOptionsPage() Widgets
        #---------Base Frame Widgets
        title = tk.Label(self, text="Application Options", font=controller.titleFont, borderwidth=2, relief="solid")
        self.explanation = tk.Label(self, text="Change aspects of the application itself.", wraplength=250, bg=controller.bgLightColor, fg=controller.textColorDark)
        self.applicationOptions_spacer = tk.Frame(self, height=15, bg=controller.bgLightColor)

        #---------Settings Menu Buttons
        self.applicationOptions_frame = tk.Frame(self, bg=controller.bgLightColor)
        self.applicationOptions_autorun_check = tk.Checkbutton(self.applicationOptions_frame, variable=autoRunVar, onvalue=True, offvalue=False, text="Enable Auto-Run On Boot", command=auto_run_toggle)
        self.applicationOptions_trayiconhue_scale = tk.Scale(self.applicationOptions_frame, orient="horizontal", variable=trayHue, command=change_hue, to=360, showvalue=False, bg=controller.bgLightColor, highlightthickness=0, borderwidth=2, relief="solid")
        applicationOptions_huevisual_canvas = tk.Canvas(self.applicationOptions_frame, bg=trayColorInHex, width=25, height=25, highlightthickness=0, borderwidth=2, relief="solid")

        #-------------------------------------------------------------------------ApplicationOptionsPage() Layout
        #--Container Frame
        self.configure(bg=controller.bgLightColor)
        title.grid(column=0, row=0)
        self.explanation.grid(column=0, row=1)
        self.applicationOptions_spacer.grid(column=0, row=2)
        self.applicationOptions_frame.grid(column=0, row=3)

        #--App Options Frame
        self.applicationOptions_autorun_check.grid(column=0, row=0, columnspan=2, pady=10)
        self.applicationOptions_trayiconhue_scale.grid(column=0, row=1, pady=5)
        applicationOptions_huevisual_canvas.grid(column=1, row=1)


#----------------------------------------------------------------------------------Main Function
def main(): 
    '''Initialization'''
    #-------------------------------------------------------------------------main() Variables
    '''
    
    Explanation:
    A lot of these don't necesarially *need* their own unique variable,
    and in fact some may only called once as of now, however I want to 
    be sure I can change things quickly and easily (like directories and 
    namings!) if I need to in future versions.

    '''
    homeDir = os.getcwd()                                       # Gets the root directory of wherever the script is called from                                  
    alphabetDir = homeDir + "/alphabetical"                     # Sets the directory for alphabetic sorting which all individual character folders will be stored
    alphabetDir_misc = alphabetDir + "/.misc_alphabetical"      # Sets the miscelanious directory for alphabetic sorting
    extDir = homeDir + "/extensions"                            # Sets the directory for extension sorting which all individual extension type folders will be stored
    extDir_misc = extDir + "/.misc_extensions"                  # Sets the miscelanious directory for extension sorting
    customDir = homeDir + "/custom"                             # Sets the directory for custom sorting which all individual custom keyword folders will be stored
    customDir_misc = customDir + "/.misc_custom"                # Sets the miscelanious directory for custom sorting
    iconDir = "icon.ico"                                       # Sets the icon directory 
    trayIconDir = "icon.png"                                   # Sets the tray icon directory 

    
    #---------------------------START OF LONG INITs
    ''' 
    
    Explanation:
    The below variables set up lists that are used during the sorting algorithm. They are long 
    and take up LOTS of room in the IDE, however I want the majority of the program to fit into
    a single file, thus here we are.
    
    '''
    iconImage_data = b"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"
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
    #---------------------------END OF LONG INITs


    #-------------------------------------------------------------------------main() Classes
    class RepeatedTimer(object): #Thanks StackOverflow! :)
        '''Repeats a function again based on a time interval'''
        '''
        
        Explanation:
        This object is used to automatically check the folder
        every second by calling the main's update() function.

        '''
        def __init__(self, interval, function, *args, **kwargs):
            '''Initialize Timer Object'''
            self._timer     = None
            self.interval   = interval
            self.function   = function
            self.args       = args
            self.kwargs     = kwargs
            self.is_running = False
            self.start()

        def _run(self):
            '''Auto-starts the timer'''
            self.is_running = False
            self.start()
            self.function(*self.args, **self.kwargs)

        def start(self):
            '''Starts the timer'''
            if not self.is_running:
                self._timer = Timer(self.interval, self._run)
                self._timer.start()
                self.is_running = True

        def stop(self):
            '''Stops the timer'''
            self._timer.cancel()
            self.is_running = False

    
    #-------------------------------------------------------------------------main() Functions
    def is_admin(): #Not used as of v1.0.0
        '''If not already, asks the user for administrator privilages'''
        try:
            return ctypes.windll.shell32.IsUserAnAdmin()
        except:
            return False

    def hide_terminal():
        '''Hides the terminal window'''
        kernel32 = ctypes.WinDLL('kernel32')    # Gets the kernal window
        user32 = ctypes.WinDLL('user32')        # Gets the user

        SW_HIDE = 0                             # Set SW_HIDE

        hWnd = kernel32.GetConsoleWindow()      # Grabs the console window
        if hWnd:                                # If it's active...
            user32.ShowWindow(hWnd, SW_HIDE)    # Hide the window

    def update():
        '''Checks for changes to root folder, then calls sort() for those changes'''
        folderContents = os.listdir(homeDir)                                            # Gets contents of the root folder in list form
        fileNameExceptions = [f"{appName}.exe", f"{appName}.py", trayIconDir, iconDir, "alphabetical", "extensions", "custom", "user_data", "autosortfolder_buglist.docx"] # Sets the names of required application files to NOT sort
        for obj in folderContents:                                                      # For every file/folder in the root folder contents...
            if os.path.basename(obj) not in fileNameExceptions:                         # If the object's name doesn't match any of the exceptions...
                sort(obj, sortingMethod)                                                # Call the correct sorting method
        logging.info(msg=f"Folder Refreshed")                                           # Log

    def check_for_directories(method):
        '''Checks for each directory's creation/existence based on the chosen sorting method'''
        if method == "alphabet":                            # Alphabet dirs
            if not os.path.exists(alphabetDir):                 # If the alphabet folder doesn't exist...
                os.mkdir(alphabetDir)                           # Create it!
            if not os.path.exists(alphabetDir_misc):            # If the alphabet misc folder doesn't exist...
                os.mkdir(alphabetDir_misc)                      # Create it!
            for char in alphabet:                               # For every character in the alphabet list...
                charPath = alphabetDir + f"/{char}"             # Create new path with index of alphabet
                if not os.path.exists(charPath):                    # If that path doesn't exist...
                    os.mkdir(charPath)                              # Create it!
        elif method == "extension":                         # Extension dirs
            if not os.path.exists(extDir):                      # If the extension folder doesn't exist...
                os.mkdir(extDir)                                # Create it!
            if not os.path.exists(extDir_misc):                 # If the extension misc folder doesn't exist...
                os.mkdir(extDir_misc)                           # Create it!
            for ext in extensions:                              # For every extension in the extension list...
                extPath = extDir + f"/{ext[0]}"                 # Create new path with index of extensions
                if not os.path.exists(extPath):                     # If that path doesn't exist...
                    os.mkdir(extPath)                               # Create it!
        elif method == "custom":                            # Custom dirs
            if not os.path.exists(customDir):                   # If the custom folder doesn't exist...
                os.mkdir(customDir)                             # Create it!
            if not os.path.exists(customDir_misc):              # If the custom misc folder doesn't exist...
                os.mkdir(customDir_misc)                        # Create it!
            for keyword in app.keywordsToSort:                  # For every keyword in app.keywordsToSort...
                customPath = customDir + f"/{keyword}"          # Create new path with index of app.keywordsToSort
                if not os.path.exists(customPath):                  # If that path doesn't exist...
                    os.mkdir(customPath)                            # Create it!

    def check_for_repeats(originalDestination, extension):
        '''Checks the destination path of a file to see if the a file of the same name already exists. If it does, " repeat(#)" is added to the end. Returns the modified directory.'''
        repeats = 1                                                                     # sets repeat value to base "1"
        if os.path.exists(originalDestination + extension):                             # if the file already exists in the destination folder...
                originalDestination += f" repeat({repeats})"                            # add "repeat(1)" to the first dupe
                if os.path.exists(originalDestination + extension):                     # if it STILL exists...
                    while os.path.exists(originalDestination + extension):              # and WHILE it still exists...
                        originalDestination = (originalDestination[::-1].replace(f"({repeats})"[::-1], "", 1))[::-1] # remove the number and parenthesis from the end of the file name
                        repeats += 1                                                    # increment the repeat value
                        originalDestination += f"({repeats})"                           # add (#) with the incremented value
        return originalDestination                                                      # return the end result

    def sort(obj, method):
        '''Determines which sorting method/algorithm is to be used and calls the representing function'''
        if method == "alphabet":        # If the sorting method is "alphabet"...
            sort_alphabetical(obj)      # Calls alphabetical sorting algorithm
        elif method == "extension":     # If the sorting method is "extension"...
            sort_extension(obj)         # Calls extension sorting algorithm
        elif method == "custom":        # If the sorting method is "custom"...
            sort_custom(obj)            # Calls custom sorting algorithm
        else:                           # Otherwise...
            pass                        # ...do nothing
        logging.info(msg=f"{obj} sorted using {method} sorting method.")    # Log

    def sort_alphabetical(file):
        '''Sorting algorithm based on first character. Takes a file and moves it to assigned folder.'''
        firstLetter = file[0].lower()                                               # First letter of file name (lowercased)
        fileTup = os.path.splitext(file)                                            # Current file name and extension in tuple (name, extension)
        fileName = fileTup[0]                                                       # Current file name
        fileExt = fileTup[1]                                                        # Current file extension
        fileCurrentPath = homeDir + f"/{fileName}{fileExt}"                         # Current file path
        fileDestinationPath = f"{alphabetDir_misc}/{fileName}{fileExt}"             # Default sorting destination path
        try:                                                                        # Try sorting in alphabet char folders
            fileDestinationPath = alphabetDir + f"/{firstLetter}/{fileName}"            # remove extension
            fileDestinationPath = check_for_repeats(fileDestinationPath, fileExt)       # check for repeats and return correct directory
            fileDestinationPath += fileExt                                              # add extension
        except:                                                                     # If it fails, put in the misc directory
            fileDestinationPath = f"{alphabetDir_misc}/{fileName}"                      # ^
            fileDestinationPath = check_for_repeats(fileDestinationPath, fileExt)       # ^
            fileDestinationPath += fileExt                                              # ^
        shutil.move(src=fileCurrentPath, dst=fileDestinationPath)                   # Finally, move the file to the correct destination folder
    
    def sort_extension(file):
        '''Sorting algorithm based on extension. Takes a file and moves it to assigned folder.'''
        fileTup = os.path.splitext(file)                                                    # Current file name and extension in tuple (name, extension)
        fileName = fileTup[0]                                                               # Current file name
        fileExt = fileTup[1]                                                                # Current file extension
        fileCurrentPath = homeDir + f"/{fileName}{fileExt}"                                 # Current file path
        fileDestinationPath = f"{extDir_misc}/{fileName}{fileExt}"                          # Default sorting destination path
        try:                                                                                # Try sorting in alphabet char folders
            for extensionList in extensions:                                                # For every extension list in extensions...
                if fileExt in extensionList:                                                # If the file extension is in the extension list...
                    fileDestinationPath = extDir + f"/{extensionList[0]}/{fileName}"            # remove extension
                    fileDestinationPath = check_for_repeats(fileDestinationPath, fileExt)       # check for repeats and return correct directory
                    fileDestinationPath += fileExt                                              # add extension
        except:                                                                             # If it fails, put in the misc directory
            fileDestinationPath = f"{extDir_misc}/{fileName}"                                   # ^
            fileDestinationPath = check_for_repeats(fileDestinationPath, fileExt)               # ^
            fileDestinationPath += fileExt                                                      # ^
        shutil.move(src=fileCurrentPath, dst=fileDestinationPath)                           # Finally, move the file to the correct destination folder
        
    def sort_custom(file):
        '''Sorting algorithm based on custom parameters. Takes a file and moves it to assigned folder.'''
        fileTup = os.path.splitext(file)                                                                                        # Current file name and extension in tuple (name, extension)
        fileName = fileTup[0]                                                                                                   # Current file name
        fileExt = fileTup[1]                                                                                                    # Current file extension
        fileCurrentPath = homeDir + f"/{fileName}{fileExt}"                                                                     # Current file path
        fileDestinationPath = f"{customDir_misc}/{fileName}{fileExt}"                                                           # Default sorting destination path
        try:                                                                                                                    # Try sorting in alphabet char folders
            for keyword in app.keywordsToSort:                                                                                  # For every keyword in app.keywordsToSort...
                if keyword in fileName:                                                                                         # If the keyword is in the filename...
                    fileDestinationPath = customDir + f"/{app.keywordsToSort[app.keywordsToSort.index(keyword)]}/{fileName}"        # remove extension
                    fileDestinationPath = check_for_repeats(fileDestinationPath, fileExt)                                           # check for repeats and return correct directory
                    fileDestinationPath += fileExt                                                                                  # add extension
        except:                                                                                                                 # If it fails, put in the misc directory
            fileDestinationPath = f"{customDir_misc}/{fileName}"                                                                    # ^
            fileDestinationPath = check_for_repeats(fileDestinationPath, fileExt)                                                   # ^
            fileDestinationPath += fileExt                                                                                          # ^
        shutil.move(src=fileCurrentPath, dst=fileDestinationPath)                                                               # Finally, move the file to the correct destination folder

    def pause_sorting():
        '''Pauses the folder updates'''
        rt.stop()                                                   # Pauses the background folder updating
        logging.info("AutoSortFolder paused.")                      # Log
        trayIcon.notify("AutoSortFolder's sorting is now paused.")  # Notify user
        app.sortingActive = False                                   # Set sorting activity state
    
    def resume_sorting():
        '''Resumes the folder updates'''
        rt.start()                                                  # Starts the background folder updating
        logging.info("AutoSortFolder resumed.")                     # Log
        trayIcon.notify("AutoSortFolder's sorting is now active.")  # Notify user
        app.sortingActive = True                                    # Set sorting activity state

    def set_sorting(icon, item):
        '''Toggle between pausing and sorting in tray icon'''
        if app.sortingActive == True:       # If sorting is active...
            pause_sorting()                 # Pause it
        else:                               # Else...
            resume_sorting()                # Resume it
        
    def exit_program(icon, item):
        '''Exits the program (forcefully)'''
        logging.info("Exiting AutoSortFolder.")     # Log
        rt.stop()                                   # Stop folder updating
        trayIcon.stop()                             # Stop tray icon
        os._exit(os.EX_OK)                          # Closes program at C level - everything closed and stopped
    
    def restart_program(icon, item):
        '''Restarts the program'''
        # logging.info("Restarting AutoSortFolder.")
        # rt.stop()
        pass
        

    '''Primary main() Code'''
    if not os.path.exists(f"{homeDir}/{trayIconDir}"):                              # If the tray icon image doesn't exist...
        with open(trayIconDir, "wb") as fh:                                         # Create it! - as png
            fh.write(base64.decodebytes(iconImage_data))                            # (using the base64 image byte data provided during init)
    appIconImage = PIL.Image.open(f"{homeDir}/{trayIconDir}")                            # Open PNG icon file 
    appIconImage.save(f"{homeDir}/{iconDir}", format="ICO")                          # Convert it to ICO
    appIconImage_path = f"{homeDir}/{iconDir}"                                       # Save the directory

    #-------------------------------------------------------------------------App Window/Vars/Dirs Initialization
    hide_terminal()                                                                     # Hides the terminal
    app = App()                                                                         # Creates App object
    app.iconbitmap(appIconImage_path)                                                   # Assign window icon
    app.mainloop()                                                                      # Executes App window loop
    sortingMethod = app.sortingMethod                                                   # When window is closed, gets the sorting method
    logging.info(msg=f"Sorting Method Chosen: {sortingMethod}")                         # Log
    appName = app.appName                                                               # Gets the application name (for directories/non-sorted folders)
    check_for_directories(sortingMethod)                                                # Checks and corrects the directories basd on the sorting method
    logging.info(msg=f"Directories: Satisfied")                                         # Log

    
    #-------------------------------------------------------------------------Start Sorting
    if app.sortingMethod != "":                                                         # If the app wasn't closed before selection...
        rt = RepeatedTimer(interval=1, function=update)                                 # Start the timer

        #-------------------------------------------------------------------------Create Tray Icon
        #if not os.path.exists(f"{homeDir}/icon.png"):                                  # If the tray icon image doesn't exist...
        #    with open(f"icon.png", "wb") as fh:                                        # Create it!
        #        fh.write(base64.decodebytes(iconImage_data))
        trayIconImage = PIL.Image.open(f"{homeDir}/{trayIconDir}")                           # Save the tray icon image as a variable
        trayIconImage = app.colorize(trayIconImage, app.trayIconHue)                    # Change hue of tray icon                    
        trayIconMenu = pystray.Menu(                                                        # Create the interactable tray icon object and menu...
            pystray.MenuItem("Pause/Resume Sorting", set_sorting),                          # Menu item that pauses/resumes sorting 
            pystray.MenuItem("Restart", restart_program, visible=False),                    # Menu item that restarts the program (not active as of v1.0.0)
            pystray.MenuItem("Exit", exit_program))                                         # Menu item that exits the program
        trayIcon = pystray.Icon("AutoSortFolder", title=f"{appName} - {app.version}", icon=trayIconImage, menu=trayIconMenu)  #Create the icon itself
        trayIcon.run()                                                                      # Execute the tray icon object
        logging.info("AutoSortFolder running! (1 second interval sorts)")                   # Log



#================================================================================================================================================================#



if __name__ == "__main__":  #If the name of the file running the script is equal to "__main__"...
    main()                  #Call main()