﻿using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using Microsoft.WindowsAPICodePack.Dialogs;
using OpenTK;
using SpotLight.EditorDrawables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GL_EditorFramework.Framework;

namespace SpotLight
{
    public partial class LevelEditorForm : Form
    {
        LevelParameterForm LPF;
        SM3DWorldLevel currentLevel;
        public LevelEditorForm()
        {
            InitializeComponent();
            
            LevelGLControlModern.CameraDistance = 20;
            
            MainSceneListView.SelectionChanged += MainSceneListView_SelectionChanged;
            MainSceneListView.ItemsMoved += MainSceneListView_ItemsMoved;

            //Properties.Settings.Default.Reset();

            if (Program.GamePath == "")
            {
                MessageBox.Show(
@"Welcome to Spotlight!

In order to use this program, you will need the folders ""StageData"" and ""ObjectData"" from Super Mario 3D World

Please select the folder than contains these folders", "Introduction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SpotlightToolStripStatusLabel.Text = "Welcome to Spotlight!";
            }
            else
                SpotlightToolStripStatusLabel.Text = "Welcome back!";

            CommonOpenFileDialog ofd = new CommonOpenFileDialog()
            {
                Title = "Select the Game Directory of Super Mario 3D World",
                IsFolderPicker = true
            };

            while (!Program.GamePathIsValid())
            {
                if (Program.GamePath != "")
                    MessageBox.Show("The Directory doesn't contain ObjectData and StageData.", "The GamePath is invalid");

                if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Program.GamePath = ofd.FileName;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }


        private void MainSceneListView_ListExited(object sender, ListEventArgs e)
        {
            currentLevel.scene.CurrentList = e.List;
            //fetch availible properties for list
            currentLevel.scene.SetupObjectUIControl(ObjectUIControl);
        }

        private void MainSceneListView_ItemsMoved(object sender, ItemsMovedEventArgs e)
        {
            currentLevel.scene.ReorderObjects(MainSceneListView.CurrentList, e.OriginalIndex, e.Count, e.Offset);
            e.Handled = true;
            LevelGLControlModern.Refresh();
        }

        private void Scene_ListChanged(object sender, GL_EditorFramework.EditorDrawables.ListChangedEventArgs e)
        {
            if (e.Lists.Contains(MainSceneListView.CurrentList))
            {
                MainSceneListView.UpdateAutoScrollHeight();
                MainSceneListView.Refresh();
            }
        }

        private void MainSceneListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentLevel == null)
                return;

            foreach (object obj in e.ItemsToDeselect)
                currentLevel.scene.ToogleSelected((EditableObject)obj, false);

            foreach (object obj in e.ItemsToSelect)
                currentLevel.scene.ToogleSelected((EditableObject)obj, true);

            e.Handled = true;
            LevelGLControlModern.Refresh();

            Scene_SelectionChanged(this, null);
        }

        private void Scene_SelectionChanged(object sender, EventArgs e)
        {
            if (currentLevel.scene.SelectedObjects.Count > 1)
            {
                lblCurrentObject.Text = "Multiple objects selected";
                string SelectedObjects = "";
                string previousobject = "";
                int multi = 1;

                List<string> selectedobjectnames = new List<string>();
                for (int i = 0; i < currentLevel.scene.SelectedObjects.Count; i++)
                    selectedobjectnames.Add(currentLevel.scene.SelectedObjects.ElementAt(i).ToString());

                selectedobjectnames.Sort();
                for (int i = 0; i < selectedobjectnames.Count; i++)
                {
                    string currentobject = selectedobjectnames[i];
                    if (previousobject == currentobject)
                    {
                        SelectedObjects = SelectedObjects.Remove(SelectedObjects.Length - (multi.ToString().Length + 1));
                        multi++;
                        SelectedObjects += $"x{multi}";
                    }
                    else if (multi > 1)
                    {
                        SelectedObjects += ", " + $"\"{currentobject}\"" + ", ";
                        multi = 1;
                    }
                    else
                    {
                        SelectedObjects += $"\"{currentobject}\"" + ", ";
                        multi = 1;
                    }
                    previousobject = currentobject;
                }
                SelectedObjects = multi > 1 ? SelectedObjects+"." : SelectedObjects.Remove(SelectedObjects.Length-2) + ".";
                SpotlightToolStripStatusLabel.Text = $"Selected {SelectedObjects}";
            }
            else if (currentLevel.scene.SelectedObjects.Count == 0)
                lblCurrentObject.Text = SpotlightToolStripStatusLabel.Text = "Nothing selected.";
            else
            {
                lblCurrentObject.Text = currentLevel.scene.SelectedObjects.First().ToString() + " selected";
                SpotlightToolStripStatusLabel.Text = $"Selected \"{currentLevel.scene.SelectedObjects.First().ToString()}\".";
            }
            MainSceneListView.Refresh();

            currentLevel.scene.SetupObjectUIControl(ObjectUIControl);
        }

        private void SplitContainer2_Panel2_Click(object sender, EventArgs e)
        {
            General3dWorldObject obj = (currentLevel.scene.SelectedObjects.First() as General3dWorldObject);
            Rail rail = (currentLevel.scene.SelectedObjects.First() as Rail);
            Debugger.Break();
        }

        #region Toolstrip Items

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "3DW Levels|*.szs", InitialDirectory = Program.StageDataPath };
                SpotlightToolStripStatusLabel.Text = "Waiting...";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "")
                LoadLevel(ofd.FileName);
            else
                SpotlightToolStripStatusLabel.Text = "Open Cancelled";
        }

        private void Scene_ObjectsMoved(object sender, EventArgs e)
        {
            ObjectUIControl.Refresh();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel == null)
                return;

            currentLevel.Save();
            SpotlightToolStripStatusLabel.Text = "Level saved!";
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel == null)
                return;

            if (currentLevel.SaveAs())
                SpotlightToolStripStatusLabel.Text = "Level saved!";
            else
                SpotlightToolStripStatusLabel.Text = "Save Cancelled or Failed.";
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm SF = new SettingsForm();
            SF.ShowDialog();
            SpotlightToolStripStatusLabel.Text = "Settings Saved.";
        }

        //----------------------------------------------------------------------------

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel == null)
                return;
            currentLevel.scene.Undo();
            LevelGLControlModern.Refresh();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel == null)
                return;
            currentLevel.scene.Redo();
            LevelGLControlModern.Refresh();
        }

        #endregion

        private void LevelParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Program.GamePath + "\\SystemData") && File.Exists(Program.GamePath + "\\SystemData\\StageList.szs"))
            {
                LPF = new LevelParameterForm(currentLevel == null ? "" : currentLevel.ToString());
                LPF.Show();
            }
            else
            {
                MessageBox.Show("StageList.szs is missing from "+Program.GamePath+"\\SystemData", "Missing File",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void DuplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel.scene.SelectedObjects.Count == 0)
                SpotlightToolStripStatusLabel.Text = "Can't duplicate nothing!";
            else
            {
                string SelectedObjects = "";
                string previousobject = "";
                int multi = 1;

                List<string> selectedobjectnames = new List<string>();
                for (int i = 0; i < currentLevel.scene.SelectedObjects.Count; i++)
                    selectedobjectnames.Add(currentLevel.scene.SelectedObjects.ElementAt(i).ToString());

                selectedobjectnames.Sort();
                for (int i = 0; i < selectedobjectnames.Count; i++)
                {
                    string currentobject = selectedobjectnames[i];
                    if (previousobject == currentobject)
                    {
                        SelectedObjects = SelectedObjects.Remove(SelectedObjects.Length - (multi.ToString().Length + 1));
                        multi++;
                        SelectedObjects += $"x{multi}";
                    }
                    else if (multi > 1)
                    {
                        SelectedObjects += ", " + $"\"{currentobject}\"" + ", ";
                        multi = 1;
                    }
                    else
                    {
                        SelectedObjects += $"\"{currentobject}\"" + ", ";
                        multi = 1;
                    }
                    previousobject = currentobject;
                }
                SelectedObjects = multi > 1 ? SelectedObjects + "." : SelectedObjects.Remove(SelectedObjects.Length - 2) + ".";

                currentLevel.scene.DuplicateSelectedObjects();

                SpotlightToolStripStatusLabel.Text = $"Duplicated {SelectedObjects}";
            }
        }

        private void OpenExToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpotlightToolStripStatusLabel.Text = "Waiting...";
            StageList STGLST = new StageList(Program.GamePath + "\\SystemData\\StageList.szs");
            LevelParamSelectForm LPSF = new LevelParamSelectForm(STGLST);
            LPSF.ShowDialog();
            if (LPSF.levelname == "")
            {
                SpotlightToolStripStatusLabel.Text = "Open Cancelled";
                return;
            }
            LoadLevel($"{Program.GamePath}\\StageData\\{LPSF.levelname}Map1.szs");
        }

        private void LoadLevel(string Filename)
        {
            SpotlightToolStripProgressBar.Value = 0;
            SpotlightToolStripStatusLabel.Text = "Loading Level...";
            if (SM3DWorldLevel.TryOpen(Filename, LevelGLControlModern, MainSceneListView, out SM3DWorldLevel level))
            {
                currentLevel = level;
                SpotlightToolStripProgressBar.Value = 50;
                SetupScene(level.scene);

                MainSceneListView.Enabled = true;
                MainSceneListView.SetRootList("ObjectList");
                MainSceneListView.ListExited += MainSceneListView_ListExited;
                MainSceneListView.Refresh();
                SpotlightToolStripProgressBar.Value = 100;
                SpotlightToolStripStatusLabel.Text = $"\"{level.ToString()}\" has been Loaded successfully.";
            }
        }

        private void SetupScene(SM3DWorldScene scene)
        {
            scene.SelectionChanged += Scene_SelectionChanged;
            scene.ListChanged += Scene_ListChanged;
            scene.ListEntered += Scene_ListEntered;
            scene.ObjectsMoved += Scene_ObjectsMoved;

            ObjectUIControl.ClearObjectUIContainers();
            ObjectUIControl.Refresh();
        }

        private void Scene_ListEntered(object sender, ListEventArgs e)
        {
            MainSceneListView.EnterList(e.List);
        }

        private void EditObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel.scene.GetType() != typeof(SM3DWorldScene))
            {
                var newScene = new SM3DWorldScene()
                {
                    ObjLists = currentLevel.scene.ObjLists,
                    LinkedObjects = currentLevel.scene.LinkedObjects,
                    UndoStack = currentLevel.scene.UndoStack,
                    RedoStack = currentLevel.scene.RedoStack
                };

                currentLevel.scene = newScene;
                SetupScene(newScene);
                LevelGLControlModern.MainDrawable = newScene;
                LevelGLControlModern.Refresh();
            }
        }

        private void EditLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel.scene.GetType() != typeof(LinkEdit3DWScene))
            {
                var newScene = new LinkEdit3DWScene()
                {
                    ObjLists = currentLevel.scene.ObjLists,
                    LinkedObjects = currentLevel.scene.LinkedObjects,
                    UndoStack = currentLevel.scene.UndoStack,
                    RedoStack = currentLevel.scene.RedoStack
                };

                currentLevel.scene = newScene;
                SetupScene(newScene);
                LevelGLControlModern.MainDrawable = newScene;
                LevelGLControlModern.Refresh();
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel == null)
                return;

            string DeletedObjects = "";
            for (int i = 0; i < currentLevel.scene.SelectedObjects.Count; i++)
                DeletedObjects += currentLevel.scene.SelectedObjects.ElementAt(i).ToString() + (i + 1 == currentLevel.scene.SelectedObjects.Count ? "." : ", ");
            SpotlightToolStripStatusLabel.Text = $"Deleted {DeletedObjects}";

            currentLevel.scene.DeleteSelected();
            LevelGLControlModern.Refresh();
            MainSceneListView.UpdateAutoScrollHeight();
            Scene_SelectionChanged(this, null);
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel == null)
                return;

            foreach (I3dWorldObject obj in currentLevel.scene.Objects)
                obj.SelectAll(LevelGLControlModern);

            LevelGLControlModern.Refresh();
            MainSceneListView.Refresh();
        }

        private void DeselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentLevel == null)
                return;

            foreach (I3dWorldObject obj in currentLevel.scene.Objects)
                obj.DeselectAll(LevelGLControlModern);

            LevelGLControlModern.Refresh();
            MainSceneListView.Refresh();
        }

        private void MainSceneListView_ItemDoubleClicked(object sender, ItemDoubleClickedEventArgs e)
        {
            if (e.Item is I3dWorldObject obj)
                LevelGLControlModern.CameraTarget = obj.GetFocusPoint();
        }
    }
}
