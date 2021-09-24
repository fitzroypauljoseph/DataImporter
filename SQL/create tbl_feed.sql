CREATE TABLE tbl_Feed

(Id int not null CONSTRAINT feed_Id UNIQUE(Id),

Name  VARCHAR(50) not null,

LastUpdated datetime not null default(current_timestamp),

Constraint pk_feed_id Primary key(Id));