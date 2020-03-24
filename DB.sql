use login_reg;

create table login(username varchar(50), password varchar(50));
create table register(username varchar(50), password varchar(50) , confirm_password varchar(50));

insert into login values('rkung', 'Rockets@88')
insert into register values('vmle88', 'Boba@88','Boba@88')

select * from login