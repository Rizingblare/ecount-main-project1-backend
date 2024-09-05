class ProductRequestDTO {
    constructor(
      searchByProdCode,
      searchByProdName,
      searchByIsused,
      orderByProdCode,
      orderByProdCodeASC,
      orderByProdName,
      orderByProdNameASC,
      pageNum,
      pageSize
    ) {
      this.searchByProdCode = searchByProdCode;
      this.searchByProdName = searchByProdName;
      this.searchByIsused = searchByIsused;
      this.orderByProdCode = orderByProdCode;
      this.orderByProdCodeASC = orderByProdCodeASC;
      this.orderByProdName = orderByProdName;
      this.orderByProdNameASC = orderByProdNameASC;
      this.pageNum = pageNum;
      this.pageSize = pageSize;
    }
  
    toQueryString() {
      const params = new URLSearchParams();
  
      // 필드가 있을 경우에만 query string에 추가
      if (this.searchByProdCode) params.append('searchByProdCode', this.searchByProdCode);
      if (this.searchByProdName) params.append('searchByProdName', this.searchByProdName);
      if (this.searchByIsused) params.append('searchByIsused', this.searchByIsused);
      if (this.orderByProdCode !== undefined) params.append('orderByProdCode', this.orderByProdCode);
      if (this.orderByProdCodeASC !== undefined) params.append('orderByProdCodeASC', this.orderByProdCodeASC);
      if (this.orderByProdName !== undefined) params.append('orderByProdName', this.orderByProdName);
      if (this.orderByProdNameASC !== undefined) params.append('orderByProdNameASC', this.orderByProdNameASC);
      if (this.pageNum !== undefined) params.append('pageNum', this.pageNum);
      if (this.pageSize !== undefined) params.append('pageSize', this.pageSize);
  
      return params.toString();
    }
  }
  
  