import axios from "axios";
import { API_URL } from "../constants";

export const archiveItem = async ({
  itemId = undefined,
  token = ``,
}: {
  itemId?: number;
  token?: string;
}) => {
  return new Promise(async (resolve, reject) => {
    if (!token || !itemId) {
      alert(`Unable to delete item. Please check if you are logged in`);
      return reject();
    }

    if (confirm(`Delete item?`)) {
      try {
        const { status } = await axios.delete(
          `${API_URL}/item-listing/${itemId}`,
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          },
        );

        if (status === 200) {
          alert(`Deleted item`);
          return resolve(true);
        } else {
          alert(`Failed to archive item`);
          return reject();
        }
      } catch (error) {
        console.error(error);
        alert(`Failed to archive item`);
        return reject();
      }
    }
  });
};
