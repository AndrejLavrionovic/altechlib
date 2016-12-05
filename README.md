# altechlib

This is project for windows application development #3 at Galway-Mayo Institute of Technology for Honour degree award title.

Altechlib is software that handling collection of books as a home library. The idea was to allow the user store books in pdf file,
delete them from library or update books details. Also book reader should be designed for its reading. The home page planed to show
the books from external resource using application programming interface

### Problems
During developing app many problems occured, many of which couldn'd be solved.
* Observable collections that held data, to be bound on frontpages, was working fine within page constructors end using get/set -ers,
but couldnt been used in event handlers such as button_clicks or listitem_selecters. As solution wasn't find flexebility of
application was reduced.

* Storing files into local derictories also gave a problem with implementation. I didn't find way how to store images into
'img' dirrectory without converting it into BitmapImage. Image picker didn't work. Worst story with PDF files. I couldn't figure out
how to store them as well.

* Another issue was when I try to build pdf reader by converting pdf pages into images. A bunch of problems was unsolvable for me.

* With no time left, I couldn't design api for external books and replaced this content by 'About Libraries' article.

### What have been done
Programm is designed to add, delete, and update books details such as author, title, isbn, genre, favorite. Navigation bar is built
as a hamburger menu on the left side of pages.
