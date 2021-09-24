CREATE TABLE tbl_Company

(Id int not null CONSTRAINT company_Id UNIQUE(Id),

Name  VARCHAR(50) not null,

LastUpdated datetime not null default(current_timestamp),

Constraint pk_company_id Primary key(Id));