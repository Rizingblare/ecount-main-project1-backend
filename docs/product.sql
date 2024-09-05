DROP TABLE IF EXISTS flow.product_kjd;

CREATE TABLE IF NOT EXISTS flow.product_kjd
(
    com_code character varying(8) NOT NULL,
    prod_cd character varying(50) NOT NULL,
    prod_nm character varying(100),
    price double,
    write_dt timestamp without time zone NOT NULL,
    is_used boolean,
    CONSTRAINT prod_kjd_pkey PRIMARY KEY (com_code, prod_cd)
);