import React from "react";
import PropTypes from "prop-types";
import { Pagination } from "@material-ui/core";

const Pager = ({ pageData, onChangePage }) => {
  let page = pageData.page + 1;
  const show = pageData.pageSize !== pageData.count;
  return (
    <div>
      {show && (
        <Pagination
          count={pageData.count}
          page={page}
          onChange={onChangePage}
        />
      )}
    </div>
  );
};

Pager.propTypes = {
  pageData: PropTypes.object.isRequired,
  onChangePage: PropTypes.func.isRequired,
};

export default Pager;
