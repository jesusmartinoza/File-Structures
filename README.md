# File-Structures
Today's operating systems allow users to organize and store files easily and easily, as do database managers. However, all this abstraction implies a great deal of work since efficiency, performance and space must be taken into account, especially when the data are numerous and resources are limited.

This brief guide will explain how the organization of archives works from an engineering perspective, as well as create a tool to manipulate the basic procedures of the organization using a data dictionary that allows to add entities, attributes, organize sequentially, indexed and using b+ trees.

## Overall structure
Excluding the Forms classes the project is composed of the following classes.
* **File.cs**. It is the core part of the project, contains methods for writing and reading the file, as well as reserving space for the indexed sequential organization and allowing manipulation of the file header.

* **Attribute.cs**. Class to represent an attribute with its respective properties.

* **Entity.cs**. Class to represent an entity with its respective attributes and methods for printing and comparing.

* **Entry.cs**. It represents a record in the program.

If we take an MVC architecture pattern as a reference, the previous classes serve as the program model and the Form classes as the controller since they contain all the logic according to the user's actions.

## Sequential
This organization contains records organized in the order in which they were entered. The order of the records is fixed. Records in sequential files can be read or written only sequentially. New records are added at the end of the file.

In this software, entities and attributes are sorted in this way because there are usually few records. 

### Entities
An entity is build as follows.
![](https://github.com/jesusmartinoza/File-Structures/blob/master/Wiki%20Assets/Entities.png?raw=true)

### Attributes
A new attribute consists of a name of 30 characters of 1 byte each, a type that says whether it is integer or 1-byte character, the length of the attribute, file address, type of index(PrimaryKey, ForeignKey, BPlusTree, Dynamic Hash), the address of index structure, and a pointer to the following attribute.
![](https://github.com/jesusmartinoza/File-Structures/blob/master/Wiki%20Assets/Attributes.png?raw=true)

## Indexed
### Primary Key
![](https://github.com/jesusmartinoza/File-Structures/blob/master/Wiki%20Assets/Primary-key.png?raw=true)
### Foreign Key
The value of this index can be repeated multiple times as it groups the indexes with the same value into a single reference, this index has two limits that are the total of pointers that a key may have and the limit of keys that may exist. 
![](https://github.com/jesusmartinoza/File-Structures/blob/master/Wiki%20Assets/Foreign-key.png?raw=true)
### B+ tree
The B+ tree index structure is the most widespread of the index structures that maintains its efficiency despite insertion and deletion of the data. A B+ tree index takes the form of a balanced tree where the root paths to each leaf of the tree are of the same length.
![](https://github.com/jesusmartinoza/File-Structures/blob/master/Wiki%20Assets/Bplus-tree.png?raw=true)
