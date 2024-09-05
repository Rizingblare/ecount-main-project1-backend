import { objectToQueryString } from "../../shared/util/formatConverter.js ";
import { API } from "../config/config.js"

export async function selectProductApi(payload) {
    const queryString = objectToQueryString(payload);
    const URL = `${API.SELECT_PRODUCT_URL}?${queryString}`;

    try {
        const response = await fetch(URL, {
            method: 'GET'
        });
        return response.json();
    }
    catch {

    }
    finally {

    }
}