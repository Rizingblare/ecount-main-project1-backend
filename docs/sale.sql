DROP TABLE IF EXISTS flow.sale_kjd;

CREATE TABLE IF NOT EXISTS flow.sale_kjd
(
    com_code character varying(8),
    io_date character(8),
    io_no integer,
    prod_cd character varying(50),
    qty integer,
    remarks character varying(100),
    CONSTRAINT sale_kjd_pkey PRIMARY KEY (com_code, io_date, io_no)
);