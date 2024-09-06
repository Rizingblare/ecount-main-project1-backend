import { API } from "../config/config.js"

export async function selectProductApi(queryString) {
    const URL = `${API.SELECT_PRODUCT_URL}?${queryString}`;

    try {
        const response = await fetch(URL, {
            method: 'GET'
        });
        return await response.json();
    }
    catch {

    }
    finally {

    }
}