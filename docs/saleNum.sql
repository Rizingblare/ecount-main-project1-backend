DROP TABLE IF EXISTS flow.saleNum_kjd;

CREATE TABLE IF NOT EXISTS flow.saleNum_kjd
(
    com_code character varying(8),
    io_date character(8),
    io_no integer,
    CONSTRAINT saleNum_kjd_pkey PRIMARY KEY (com_code, io_date)
);