# vamp#
# 
# A VLC, Chromium and NAudio based video and multimedia player for a HTPC use.
# Copyright © 2018 VPKSoft, Petteri Kautonen
# 
# Contact: vpksoft@vpksoft.net
# 
# This file is part of vamp#.
# 
# vamp# is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
# 
# vamp# is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
# 
# You should have received a copy of the GNU General Public License
# along with vamp#.  If not, see <http://www.gnu.org/licenses/>.
# 

SetCompressor /SOLID /FINAL lzma

Name "vamp#"

# General Symbol Definitions
!define REGKEY "SOFTWARE\$(^Name)"
!define VERSION 1.0.0.4
!define COMPANY VPKSoft
!define URL http://www.vpksoft.net

# MUI Symbol Definitions
!define MUI_ICON ..\icon.ico
!define MUI_FINISHPAGE_NOAUTOCLOSE
!define MUI_STARTMENUPAGE_REGISTRY_ROOT HKLM
!define MUI_STARTMENUPAGE_NODISABLE
!define MUI_STARTMENUPAGE_REGISTRY_KEY ${REGKEY}
!define MUI_STARTMENUPAGE_REGISTRY_VALUENAME StartMenuGroup
!define MUI_STARTMENUPAGE_DEFAULTFOLDER "vamp#"
!define MUI_UNICON .\un_icon.ico
!define MUI_UNFINISHPAGE_NOAUTOCLOSE
!define MUI_LANGDLL_REGISTRY_ROOT HKLM
!define MUI_LANGDLL_REGISTRY_KEY ${REGKEY}
!define MUI_LANGDLL_REGISTRY_VALUENAME InstallerLanguage
BrandingText "vamp#"

#Include the LogicLib
!include 'LogicLib.nsh'
!include "x64.nsh"
#!include "FileAssoc.nsh"
!include "InstallOptions.nsh"
!include "DotNetChecker.nsh"

# Included files
!include Sections.nsh
!include MUI2.nsh

# Reserved Files
!insertmacro MUI_RESERVEFILE_LANGDLL

# Variables
Var StartMenuGroup

# Installer pages
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE .\license.txt
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_STARTMENU Application $StartMenuGroup
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

# Installer languages
!insertmacro MUI_LANGUAGE English
!insertmacro MUI_LANGUAGE Finnish

# Installer attributes
OutFile setup_vampsharp_1_0_0_4.exe
InstallDir "$PROGRAMFILES64\vamp#"
CRCCheck on
XPStyle on
ShowInstDetails hide
VIProductVersion 1.0.0.4
VIAddVersionKey /LANG=${LANG_ENGLISH} ProductName "vamp# installer"
VIAddVersionKey /LANG=${LANG_ENGLISH} ProductVersion "${VERSION}"
VIAddVersionKey /LANG=${LANG_ENGLISH} CompanyName "${COMPANY}"
VIAddVersionKey /LANG=${LANG_ENGLISH} CompanyWebsite "${URL}"
VIAddVersionKey /LANG=${LANG_ENGLISH} FileVersion "${VERSION}"
VIAddVersionKey /LANG=${LANG_ENGLISH} FileDescription "vamp#"
VIAddVersionKey /LANG=${LANG_ENGLISH} LegalCopyright "Copyright © VPKSoft 2018"
InstallDirRegKey HKLM "${REGKEY}" Path
ShowUninstDetails hide

# Installer sections
Section -Main SEC0000
    SetOutPath $INSTDIR
    SetOverwrite on

    !insertmacro CheckNetFramework 461	

    SetOutPath $TEMP
    File .\2015\vc_redist.x64.exe
    File .\2015\vc_redist.x86.exe
    ${If} ${RunningX64}
       ExecWait '"$TEMP\vc_redist.x64.exe" /install /passive /norestart /quiet'
    ${Else}
       ExecWait '"$TEMP\vc_redist.x86.exe" /install /passive /norestart /quiet'
    ${EndIf}

    Delete $TEMP\vc_redist.x64.exe
    Delete $TEMP\vc_redist.x86.exe
   
   
    SetOutPath $INSTDIR
	
	File ".\instructions\vamp# instructions.pdf"
	
    File /r /x .svn ..\vamp\bin\Release\*.*
	
	File ..\thanks_to.odt

	File ..\settings.ico
	File ..\album_editor.ico
	File ..\languages.ico

    /*	
	SetOutPath $INSTDIR\libvlc_x64
    File /r /x .svn ..\vamp\libvlc_x64\*.*
	
	SetOutPath $INSTDIR\libvlc_x86
	File /r /x .svn ..\vamp\libvlc_x86\*.*

	SetOutPath $INSTDIR\Firefox_x64
	File /r ..\packages\Geckofx45.64.45.0.34\content\Firefox\*.*
	
	SetOutPath $INSTDIR\Firefox_x86
	File /r ..\packages\Geckofx45.45.0.34\content\Firefox\*.*
	*/
	
    SetOutPath "$LOCALAPPDATA\vamp#"
    File ..\lang.sqlite   
   
   
	SetOutPath $SMPROGRAMS\$StartMenuGroup
    CreateShortcut "$SMPROGRAMS\$StartMenuGroup\vamp#.lnk" $INSTDIR\vamp#.exe	
	CreateShortcut "$SMPROGRAMS\$StartMenuGroup\$(SettingsDesc).lnk" $INSTDIR\vamp#.exe "--configure" "$INSTDIR\settings.ico" 0
	CreateShortcut "$SMPROGRAMS\$StartMenuGroup\$(PhotoEditorDesc).lnk" $INSTDIR\vamp#.exe "--photos" "$INSTDIR\album_editor.ico" 0
	CreateShortcut "$SMPROGRAMS\$StartMenuGroup\$(InstructionsDesc).lnk" "$INSTDIR\vamp# instructions.pdf"
	CreateShortcut "$SMPROGRAMS\$StartMenuGroup\$(LocalizeDesc).lnk" "$INSTDIR\vamp#.exe" '"--localize=$LOCALAPPDATA\vamp#\lang.sqlite" ' "$INSTDIR\languages.ico" 0
	
    WriteRegStr HKLM "${REGKEY}\Components" Main 1
SectionEnd

Section -post SEC0001
    WriteRegStr HKLM "${REGKEY}" Path $INSTDIR
    SetOutPath $INSTDIR
    WriteUninstaller $INSTDIR\uninstall_ampsharp.exe
    !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    SetOutPath $SMPROGRAMS\$StartMenuGroup
    CreateShortcut "$SMPROGRAMS\$StartMenuGroup\$(^UninstallLink).lnk" $INSTDIR\uninstall_ampsharp.exe
    !insertmacro MUI_STARTMENU_WRITE_END
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" DisplayName "$(^Name)"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" DisplayVersion "${VERSION}"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" Publisher "${COMPANY}"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" URLInfoAbout "${URL}"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" DisplayIcon $INSTDIR\uninstall_ampsharp.exe
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" UninstallString $INSTDIR\uninstall_ampsharp.exe
    WriteRegDWORD HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" NoModify 1
    WriteRegDWORD HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" NoRepair 1
SectionEnd

# Macro for selecting uninstaller sections
!macro SELECT_UNSECTION SECTION_NAME UNSECTION_ID
    Push $R0
    ReadRegStr $R0 HKLM "${REGKEY}\Components" "${SECTION_NAME}"
    StrCmp $R0 1 0 next${UNSECTION_ID}
    !insertmacro SelectSection "${UNSECTION_ID}"
    GoTo done${UNSECTION_ID}
next${UNSECTION_ID}:
    !insertmacro UnselectSection "${UNSECTION_ID}"
done${UNSECTION_ID}:
    Pop $R0
!macroend

# Uninstaller sections
Section /o -un.Main UNSEC0000
    Delete /REBOOTOK "$SMPROGRAMS\$StartMenuGroup\vamp#.lnk"
    Delete /REBOOTOK "$SMPROGRAMS\$StartMenuGroup\$(SettingsDesc).lnk"
    Delete /REBOOTOK "$SMPROGRAMS\$StartMenuGroup\$(PhotoEditorDesc).lnk"
	Delete /REBOOTOK "$SMPROGRAMS\$StartMenuGroup\$(InstructionsDesc).lnk"
	Delete /REBOOTOK "$SMPROGRAMS\$StartMenuGroup\$(LocalizeDesc).lnk"	

	RMDir /r /REBOOTOK $INSTDIR
	
	Call un.DeleteLocalData
	
    DeleteRegValue HKLM "${REGKEY}\Components" Main
SectionEnd

Section -un.post UNSEC0001
    DeleteRegKey HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)"
    Delete /REBOOTOK "$SMPROGRAMS\$StartMenuGroup\$(^UninstallLink).lnk"
    Delete /REBOOTOK $INSTDIR\uninstall_ampsharp.exe
    DeleteRegValue HKLM "${REGKEY}" StartMenuGroup
    DeleteRegValue HKLM "${REGKEY}" Path
    DeleteRegKey /IfEmpty HKLM "${REGKEY}\Components"
    DeleteRegKey /IfEmpty HKLM "${REGKEY}"
	
    RMDir /REBOOTOK $SMPROGRAMS\$StartMenuGroup
	
    RMDir /REBOOTOK $INSTDIR
SectionEnd

# Installer functions
Function .onInit
    InitPluginsDir
    !insertmacro MUI_LANGDLL_DISPLAY    
FunctionEnd

# Uninstaller functions
Function un.onInit
    ReadRegStr $INSTDIR HKLM "${REGKEY}" Path
    !insertmacro MUI_STARTMENU_GETFOLDER Application $StartMenuGroup
    !insertmacro MUI_UNGETLANGUAGE
    !insertmacro SELECT_UNSECTION Main ${UNSEC0000}
FunctionEnd

Function un.DeleteLocalData
	MessageBox MB_ICONQUESTION|MB_YESNO "$(DeleteUserData)" IDYES deletelocal IDNO nodeletelocal
	deletelocal:
    RMDir /r /REBOOTOK "$LOCALAPPDATA\vamp#"
	nodeletelocal:
FunctionEnd

# Installer Language Strings
# TODO Update the Language Strings with the appropriate translations.

LangString ^UninstallLink ${LANG_ENGLISH} "Uninstall $(^Name)"
LangString ^UninstallLink ${LANG_FINNISH} "Poista $(^Name)"

# localization..
LangString SettingsDesc ${LANG_FINNISH} "vamp# asetukset"
LangString SettingsDesc ${LANG_ENGLISH} "vamp# settings"

LangString PhotoEditorDesc ${LANG_FINNISH} "vamp# valokuva-albumieditori"
LangString PhotoEditorDesc ${LANG_ENGLISH} "vamp# photo album editor"

LangString DeleteUserData ${LANG_FINNISH} "Poista paikalliset käyttäjätiedot?"
LangString DeleteUserData ${LANG_ENGLISH} "Delete local user data?"

LangString InstructionsDesc ${LANG_FINNISH} "vamp# ohjeet - englanti (Yhdysvallat)"
LangString InstructionsDesc ${LANG_ENGLISH} "vamp# instructions - English (United states)"

LangString LocalizeDesc ${LANG_FINNISH} "Lokalisointi"
LangString LocalizeDesc ${LANG_ENGLISH} "Localization"
#END: localization..
