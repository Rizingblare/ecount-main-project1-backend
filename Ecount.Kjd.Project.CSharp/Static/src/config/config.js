export const MODE = {
    ADD: Symbol(),
    EDIT: Symbol()
};

export const URL = {
    INDEX: 'index.html',
    PROD: 'prod.html',
    PROD_EDIT: 'prodEdit.html',
    SALE: 'sale.html',
    SALE_EDIT: 'saleEdit.html'
};

export const API = {
    SELECT_PRODUCT_URL: '/api/product/select',
    INSERT_PRODUCT_URL: '/api/product/insert',
    UPDATE_PRODUCT_URL: '/api/product/update',
    DELETE_PRODUCT_URL: '/api/product/delete',
    SELECT_SALE_URL: '/api/sale/select',
    INSERT_SALE_URL: '/api/sale/insert',
    UPDATE_SALE_URL: '/api/sale/update',
    DELETE_SALE_URL: '/api/sale/delete'
};

export const PROD_CONFIG = {
    SECRET_KEY : 'prod',
    PRIMARY_KEY : 'id',
}

export const SALE_CONFIG = {
    SECRET_KEY : 'sale',
    PRIMARY_KEY : 'id',
}