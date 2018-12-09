###### BEGIN GPL LICENSE BLOCK #####
#
#Copyright (C) 2018 Raisy Clutch
#raisycltch@gmail.com
#
#Created by Raisy Clutch
#
#   This program is free software: you can redistribute it and/or modify
#    it under the terms of the GNU General Public License as published by
#    the Free Software Foundation, either version 3 of the License, or
#    (at your option) any later version.
#
#    This program is distributed in the hope that it will be useful,
#    but WITHOUT ANY WARRANTY; without even the implied warranty of
#    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
#    GNU General Public License for more details.
#
#    You should have received a copy of the GNU General Public License
#    along with this program.  If not, see <http://www.gnu.org/licenses/>.
#
#
## ##### END GPL LICENSE BLOCK #####

bl_info = {
    "name": "Bacutor Addon Creator",
    "author": "Raisy Clutch",
    "version": (1, 0),
    "blender": (2, 78, 0),
    "location": "View3D > Tools",
    "description": "Runs Bacutor from Blender",
    "warning": "",
    "wiki_url": "",
    "category": "Development",
    }


import bpy
import os
from bpy.types import Operator
from bpy.props import FloatVectorProperty
from bpy_extras.object_utils import AddObjectHelper, object_data_add

exe_path = os.path.dirname(__file__)

def winpath(path):
  return path.replace("\\", "\\\\")

def exec_bacutor(self, context):
    catfile = winpath(os.path.join(exe_path, "bin\\\\Bacutor.exe"))
    os.startfile(catfile)


class run_bacutor(Operator, AddObjectHelper):
    """This will run bacutor from blender"""
    bl_idname = "bacutor.add_object"
    bl_label = "Bacutor"
    bl_options = {'REGISTER', 'UNDO'}

    def execute(self, context):

        exec_bacutor(self, context)

        return {'FINISHED'}


# Registration

class BacutorPanel(bpy.types.Panel):
    """Creates a Panel in the Object properties window"""
    bl_label = "Bacutor"
    bl_idname = "ObjectPanel"
    bl_space_type = 'PROPERTIES'
    bl_region_type = 'WINDOW'
    bl_context = "object"

    def draw(self, context):
        layout = self.layout
        row = layout.row()
        row.label(text="Bacutor Addon Creator", icon='PMARKER_ACT')
        row = layout.row()
        row.label(text="Create Addons Faster and Easier")
        row = layout.row()
        row.operator("bacutor.add_object")
        
class TBacutorPanel(bpy.types.Panel):
    """Creates a Panel in the Text Editor properties window"""
    bl_label = "Bacutor"
    bl_idname = "TextEditorPanel"
    bl_space_type = 'TEXT_EDITOR'
    bl_region_type = 'UI'
    bl_context = "object"

    def draw(self, context):
        layout = self.layout
        row = layout.row()
        row.label(text="Bacutor Addon Creator", icon='PMARKER_ACT')
        row = layout.row()
        row.label(text="Create Addons Faster and Easier")
        row = layout.row()
        row.operator("bacutor.add_object")

class ToBacutorPanel(bpy.types.Panel):
    """Creates a Panel in the Tools window"""
    bl_label = "Bacutor"
    bl_idname = "ToolsPanel"
    bl_space_type = 'VIEW_3D'
    bl_region_type = 'UI'
    bl_context = "Tools"

    def draw(self, context):
        layout = self.layout
        row = layout.row()
        row.label(text="Bacutor Addon Creator", icon='PMARKER_ACT')
        row = layout.row()
        row.label(text="Create Addons Faster and Easier")
        row = layout.row()
        row.operator("bacutor.add_object")


def register():
    bpy.utils.register_class(run_bacutor)
    bpy.utils.register_class(BacutorPanel)
    bpy.utils.register_class(TBacutorPanel)
    bpy.utils.register_class(ToBacutorPanel)


def unregister():
    bpy.utils.unregister_class(run_bacutor)
    bpy.utils.unregister_class(BacutorPanel)
    bpy.utils.unregister_class(TBacutorPanel)
    bpy.utils.unregister_class(ToBacutorPanel)

if __name__ == "__main__":
    register()
