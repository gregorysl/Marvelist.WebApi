import React from 'react';
import { shallow } from 'enzyme';
import TextHeader from './TextHeader';

describe('<TextHeader />', () => {
  it('should return h1 type', () => {
    const wrapper = shallow(<TextHeader />);
    expect(wrapper.type()).toEqual("h1");
  });
  it('should return text for search results with props text', () => {
    const props = {
      text: "test"
    };
    const wrapper = shallow(<TextHeader {...props} />);
    expect(wrapper.find('h1').text()).toEqual("Search results for \"test\"");
  });
  it('should return raw text', () => {
    const props = {
      raw: "test"
    };
    const wrapper = shallow(<TextHeader {...props} />);
    expect(wrapper.find('h1').text()).toEqual(props.raw);
  });
  it('should return text Series without props', () => {
    const wrapper = shallow(<TextHeader />);
    expect(wrapper.find('h1').text()).toEqual("Series");
  });
});
