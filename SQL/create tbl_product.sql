CREATE TABLE tbl_Product

(CompanyId int not null,

FeedId int not null,

ProductId int not null,

LastUpdated datetime not null default(current_timestamp),

Constraint ck_company_feed_product_id Primary key(CompanyId,FeedId,ProductId));