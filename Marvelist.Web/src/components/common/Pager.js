import React from "react";
import { Pagination } from "@material-ui/core";

const Pager = ({ pageData, onChangePage }) => {
  let page = pageData.page + 1;
  const show = pageData.pageSize !== pageData.count;
  return show ? (
    <Pagination count={pageData.count} page={page} onChange={onChangePage} />
  ) : (
    <></>
  );
};

export default Pager;
