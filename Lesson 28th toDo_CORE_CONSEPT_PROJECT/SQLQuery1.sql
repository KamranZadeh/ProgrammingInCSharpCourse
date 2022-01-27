--Course
--Id
--Name
--Duration (in months)
--Price (AZN)
--CreationTime
--ModificationTime

create table tableCourse
( Id int,
Name nvarchar(50),
Duration int,
CreationTime datetime,
ModificationTime datetime
)

drop table tableStudent
select * from tableStudent
select * from tableTeacher
select * from tableCourse

CREATE SEQUENCE tableCourseSequance
 AS INT
 START WITH 1
 INCREMENT BY 1

 insert into tableStudent values (next value for tableStudentSequance, 'Kamran', 'Zadeh', '19940914', null, null)
 insert into tableTeacher values (next value for tableTeacherSequance, 'Kamran', 'Zadeh', '19940914', 'Math')
 insert into tableCourse values (next value for tableCourseSequance, 'Math', 12, null, null)
