import { Fragment } from "react/cjs/react.production.min";
import AvailableMeals from "./available-meals";
import MealsSummery from "./meals-summery";

const Meals = () => {
  return (
    <Fragment>
      <MealsSummery />
      <AvailableMeals />
    </Fragment>
  );
};

export default Meals;
