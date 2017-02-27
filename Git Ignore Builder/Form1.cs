﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Git_Ignore_Builder
{
    public partial class App : Form
    {
        private FolderBrowserDialog browseFolder;
        private string folderPath;
        private string fullPath;

        public App()
        {
            Console.WriteLine("Loading...");
            InitializeComponent();
            initEnv();
            Console.WriteLine("Done");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            browseButton.Click += new EventHandler(this.Browse_Click);
            generateButton.Click += new EventHandler(this.Generate_File);

        }

        private void Browse_Click(object sender, EventArgs e)
        {
            browseFolder.ShowDialog();
            folderPath = browseFolder.SelectedPath;
            fullPath = folderPath + "/.gitignore";
            Console.WriteLine("The selected folder is " + folderPath);
            if (File.Exists(fullPath) == true)
            {
                generateButton.Text = "Overwrite";
            }
            generateButton.Enabled = true;
        }

        private void initEnv()
        {
            browseFolder = new FolderBrowserDialog();
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            //Quick and dirty
            var items = new[] {
                new { Text = "Unity", Value = "unity" },
                new { Text = "openFrameworks", Value = "of" },
                new { Text = "p5", Value = "p5" },
                new { Text = "Processing", Value = "processing" }
            };
            comboBox1.DataSource = items;
        }

        private void Generate_File(object sender, EventArgs e)
        {
            writeFile(comboBox1.SelectedValue.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedItem);
        }
        private void writeFile(string platform)
        {
            StreamWriter sw = new StreamWriter(fullPath);
            sw.WriteLine("#Generated by .gitignore generator");
            sw.WriteLine("#Generator written by juniorxsound (http://orfleisher.com)");
            sw.WriteLine("");
            if (platform == "unity")
            {
                sw.WriteLine("*/[Ll]ibrary/");
                sw.WriteLine("*/[Tt]emp/");
                sw.WriteLine("*/[Oo]bj/");
                sw.WriteLine("*/[Bb]uild/");
                sw.WriteLine("*/[Bb]uilds/");
                sw.WriteLine("*/Assets/AssetStoreTools*");
                sw.WriteLine("");
                sw.WriteLine("# Autogenerated VS/MD solution and project files");
                sw.WriteLine("ExportedObj/");
                sw.WriteLine("*.csproj");
                sw.WriteLine("*.unityproj");
                sw.WriteLine("*.sln");
                sw.WriteLine("*.suo");
                sw.WriteLine("*.tmp");
                sw.WriteLine("*.user");
                sw.WriteLine("*.userprefs");
                sw.WriteLine("*.pidb");
                sw.WriteLine("*.booproj");
                sw.WriteLine("*.svd");
                sw.WriteLine("");
                sw.WriteLine("# Unity3D generated meta files");
                sw.WriteLine("*.pidb.meta");
                sw.WriteLine("");
                sw.WriteLine("# Unity3D Generated File On Crash Reports");
                sw.WriteLine("sysinfo.txt");
                sw.WriteLine("");
                sw.WriteLine("*.DS_Store");
                sw.WriteLine("");
                sw.WriteLine("# Builds");
                sw.WriteLine("*.apk");
                sw.WriteLine("*.unitypackage");
            } else if (platform == "of")
            {
                sw.WriteLine("#########################");
                sw.WriteLine("# openFrameworks patterns");
                sw.WriteLine("#########################");
                sw.WriteLine("");
                sw.WriteLine("# build files");
                sw.WriteLine("openFrameworks.a");
                sw.WriteLine("openFrameworksDebug.a");
                sw.WriteLine("openFrameworksUniversal.a");
                sw.WriteLine("libs/openFrameworksCompiled/lib/*/*");
                sw.WriteLine("!libs/openFrameworksCompiled/lib/*/.gitkeep");
                sw.WriteLine("");
                sw.WriteLine("# apothecary");
                sw.WriteLine("scripts/apothecary");
                sw.WriteLine("");
                sw.WriteLine("# rule to avoid non-official addons going into git");
                sw.WriteLine("# see addons/.gitignore");
                sw.WriteLine("addons/*");
                sw.WriteLine("# rule to avoid non-official apps going into git");
                sw.WriteLine("# see apps/.gitignore");
                sw.WriteLine("apps/*");
                sw.WriteLine("# rule to ignore compiled / downloaded libs");
                sw.WriteLine("/libs/*");
                sw.WriteLine("!/libs/openFrameworks");
                sw.WriteLine("!/libs/openFrameworksCompiled");
                sw.WriteLine("# also, see examples/.gitignore");
                sw.WriteLine("");
                sw.WriteLine("#########################");
                sw.WriteLine("# general");
                sw.WriteLine("#########################");
                sw.WriteLine("[Bb]uild/");
                sw.WriteLine("[Oo]bj/");
                sw.WriteLine("*.o");
                sw.WriteLine("examples/**/[Dd]ebug*/");
                sw.WriteLine("examples/**/[Rr]elease*/");
                sw.WriteLine("examples/**/gcc-debug/");
                sw.WriteLine("examples/**/gcc-release/");
                sw.WriteLine("tests/**/[Dd]ebug*/");
                sw.WriteLine("tests/**/[Rr]elease*/");
                sw.WriteLine("tests/**/gcc-debug/");
                sw.WriteLine("tests/**/gcc-release/");
                sw.WriteLine("*.mode*");
                sw.WriteLine("*.app/");
                sw.WriteLine("*.pyc");
                sw.WriteLine(".svn/");
                sw.WriteLine("*.log");
                sw.WriteLine("*.cpp.eep");
                sw.WriteLine("*.cpp.elf");
                sw.WriteLine("*.cpp.hex");
                sw.WriteLine("");
                sw.WriteLine("#########################");
                sw.WriteLine("# IDE");
                sw.WriteLine("#########################");
                sw.WriteLine("# XCode");
                sw.WriteLine("*.pbxuser");
                sw.WriteLine("*.perspective");
                sw.WriteLine("*.perspectivev3");
                sw.WriteLine("*.mode1v3");
                sw.WriteLine("*.mode2v3");
                sw.WriteLine("# XCode 4");
                sw.WriteLine("xcuserdata");
                sw.WriteLine("*.xcworkspace");
                sw.WriteLine("# Code::Blocks");
                sw.WriteLine("*.depend");
                sw.WriteLine("*.layout");
                sw.WriteLine("# Visual Studio");
                sw.WriteLine("*.sdf");
                sw.WriteLine("*.opensdf");
                sw.WriteLine("*.suo");
                sw.WriteLine("*.pdb");
                sw.WriteLine("*.ilk");
                sw.WriteLine("*.aps");
                sw.WriteLine("ipch/");
                sw.WriteLine("# Eclipse");
                sw.WriteLine(".metadata");
                sw.WriteLine(" local.properties");
                sw.WriteLine(".externalToolBuilders");
                sw.WriteLine("# Android Studio");
                sw.WriteLine(".idea");
                sw.WriteLine(".gradle");
                sw.WriteLine("gradle");
                sw.WriteLine("gradlew");
                sw.WriteLine("gradlew.bat");
                sw.WriteLine("");
                sw.WriteLine("# QtCreator");
                sw.WriteLine("*.qbs.user");
                sw.WriteLine("*.pro.user");
                sw.WriteLine("*.pri");
                sw.WriteLine("");
                sw.WriteLine("#########################");
                sw.WriteLine("# operating system");
                sw.WriteLine("#########################");
                sw.WriteLine("# Linux");
                sw.WriteLine("*~");
                sw.WriteLine("# KDE");
                sw.WriteLine(".directory");
                sw.WriteLine(".AppleDouble");
                sw.WriteLine("# OSX");
                sw.WriteLine(".DS_Store");
                sw.WriteLine("*.swp");
                sw.WriteLine("*~.nib");
                sw.WriteLine("# Thumbnails");
                sw.WriteLine("._*");
                sw.WriteLine("examples/ios/**/mediaAssets");
                sw.WriteLine("# Windows");
                sw.WriteLine("# Windows image file caches");
                sw.WriteLine("Thumbs.db");
                sw.WriteLine("# Folder config file");
                sw.WriteLine("Desktop.ini");
                sw.WriteLine("");
                sw.WriteLine("# Android");
                sw.WriteLine(".csettings");
                sw.WriteLine("/libs/openFrameworksCompiled/project/android/paths.make");
                sw.WriteLine("# Android Studio");
                sw.WriteLine("*.iml");
                sw.WriteLine("");
                sw.WriteLine("#########################");
                sw.WriteLine("# miscellaneous");
                sw.WriteLine("#########################");
                sw.WriteLine(".mailmap");
                sw.WriteLine("/apps*/");
            } else if ( platform == "p5")
            {
                sw.WriteLine("# Logs");
                sw.WriteLine("logs");
                sw.WriteLine("*.log");
                sw.WriteLine("npm-debug.log*");
                sw.WriteLine("");
                sw.WriteLine("# Grunt intermediate storage (http://gruntjs.com/creating-plugins#storing-task-files)");
                sw.WriteLine(".grunt");
                sw.WriteLine("");
                sw.WriteLine("# Bower dependency directory (https://bower.io/)");
                sw.WriteLine("bower_components");
                sw.WriteLine("");
                sw.WriteLine("# Dependency directories");
                sw.WriteLine("node_modules/");
            } else if ( platform == "processing")
            {
                sw.WriteLine("#################################");
                sw.WriteLine("# Java generated files #");
                sw.WriteLine("#################################");
                sw.WriteLine("*.class");
                sw.WriteLine("*.java");
                sw.WriteLine("# Package Files #");
                sw.WriteLine("*.jar");
                sw.WriteLine("*.war");
                sw.WriteLine("*.ear");

                sw.WriteLine("#################################");
                sw.WriteLine("# Processing files              #");
                sw.WriteLine("#################################");
                sw.WriteLine("sketch.properties");
                sw.WriteLine("applet");
                sw.WriteLine("application.macosx");
                sw.WriteLine("build-tmp/");
                sw.WriteLine("web-export/");

            }

            //Include this in all .gitignore versions
            sw.WriteLine("");
            sw.WriteLine("#################################");
            sw.WriteLine("# OS generated files            #");
            sw.WriteLine("#################################");
            sw.WriteLine(".DS_Store");
            sw.WriteLine(".DS_Store?");
            sw.WriteLine("._*");
            sw.WriteLine(".Spotlight-V100");
            sw.WriteLine(".Trashes");
            sw.WriteLine("Thumbs.db");
            sw.WriteLine("Desktop.ini");
            sw.Close();

            generateButton.Text = "Generate";
            generateButton.Enabled = false;
            
        }
    }
}